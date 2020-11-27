using UnityEngine;

public class DroneEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _particles;
    private DroneEnemyModel _drone;
    private PlayerParametersModel _player;
    private Animator _animator;
    private float _distance;
    private Rigidbody _rig;
    private NanoBotInstantiate _nanoAgent;



    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.isKinematic = true;
        _player = FindObjectOfType<PlayerParametersModel>();
        _drone = GetComponent<DroneEnemyModel>();
        _animator = GetComponent<Animator>();
        BIRNBIRNBIRN(false);
    }

    private void Update()
    {
        if (_drone.IsDead)
        {
            _animator.enabled = false;
            //Вызов Партиклов 
            _nanoAgent.MakeParticle();
            _rig.isKinematic = false;
            _rig.AddForce(Vector3.forward * -1.0f, ForceMode.Impulse);
            Destroy(gameObject, 10.0f);            
        }        

        _distance = Vector3.Distance(transform.position, _player.transform.position);

        if (_distance <= _drone.GetViewRange() && !_drone.IsDead)
        {
            transform.LookAt(_player.transform);

            if (_distance <= _drone.GetAttackRange())
            {
                _animator.SetBool("Flying", false);
                BIRNBIRNBIRN(true);
            }
            else
            {
                BIRNBIRNBIRN(false);
                Moving();
            }
        }
    }

    private void Moving()
    {
        _animator.SetBool("Flying", true);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _drone.GetSpeed() * Time.deltaTime);
    }
    private void BIRNBIRNBIRN(bool state)
    {
        _particles.SetActive(state);
        if (state == true && _distance <= _drone.GetAttackRange() && _distance >= _drone.GetAttackRange() - 2f)
        {
            _player.GetDamage(_drone.GetAttackPower() * Time.deltaTime);
        }
    }
}
