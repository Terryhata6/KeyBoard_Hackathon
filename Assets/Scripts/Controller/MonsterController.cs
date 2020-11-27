using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private PlayerParametersModel _player;
    private MonsterModel _enemy;
    private Animator _animator;
    private MonsterState _state;
    private Rigidbody _rig;
    private NanoBotInstantiate _nanoAgent;

    private float _distance;

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.isKinematic = true;
        _player = FindObjectOfType<PlayerParametersModel>();
        _enemy = GetComponent<MonsterModel>();
        _animator = GetComponent<Animator>();
        _nanoAgent = GetComponent<NanoBotInstantiate>();

    }

    private void Update()
    {
        if (_enemy.IsDead)
        {
            _animator.enabled = false;
            //Вызов партиклов
            _nanoAgent.MakeParticle();
            _rig.isKinematic = false;
            _rig.AddForce(Vector3.forward * -1.0f, ForceMode.Impulse);
            Destroy(gameObject, 10.0f);
        }


        
        _distance = Vector3.Distance(transform.position, _player.transform.position);

        if (_distance <= _enemy.GetRangeOfView() && !_enemy.IsDead)
        {
            transform.LookAt(_player.transform);
            if (_distance <= _enemy.GetRangeOfAttack())
            {
                Attack();
            }
            else
            {
                Moving();
            }
        }
        else
        {
            Chillout();
        }
    }

    private void Moving()
    {
        _animator.SetBool(MonsterAnimatorStrings.UnderDamage, false);
        _animator.SetBool(MonsterAnimatorStrings.Attack, false);
        _animator.SetBool(MonsterAnimatorStrings.Walk, true);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _enemy.GetSpeed() * Time.deltaTime);
    }
    private void Attack()
    {
        _animator.SetBool(MonsterAnimatorStrings.UnderDamage, false);
        _animator.SetBool(MonsterAnimatorStrings.Walk, false);
        _animator.SetBool(MonsterAnimatorStrings.Attack, true);
    }
    private void Chillout()
    {
        _animator.SetBool(MonsterAnimatorStrings.Walk, false);
        _animator.SetBool(MonsterAnimatorStrings.Attack, false);
        _animator.SetBool(MonsterAnimatorStrings.UnderDamage, false);
    }

    public void GetDamage(float damage)
    {
        _enemy.GetDamage(damage);

        _animator.SetBool(MonsterAnimatorStrings.Walk, false);
        _animator.SetBool(MonsterAnimatorStrings.Attack, false);
        _animator.SetBool(MonsterAnimatorStrings.UnderDamage, true);
    }

}
