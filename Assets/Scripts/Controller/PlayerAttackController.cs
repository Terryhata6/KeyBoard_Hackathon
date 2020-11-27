using UnityEngine;
using System.Collections;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private IdleDissolveController _sword;
    [SerializeField] private IdleDissolveKnifeController _knife;
    [SerializeField] private Transform _knifeStartTransform;
    [SerializeField] private float _knifeSpeed = 300.0f;

    private PlayerParametersModel _playerModel;
    private CustomInputManager _input;
    private Animator _animator;

    [SerializeField] private float _comboTime = 0.0f;
    [SerializeField] private float _maxComboTime = 10.0f;
    [SerializeField] private bool _aimStance;

    private float _attackPower;
    private float _attackRange;
    private bool _isAttacking;
    private bool _comboEnder;
    private bool _comboEnd;


    private void Start()
    {
        _aimStance = false;        
        _playerModel = GetComponent<PlayerParametersModel>();
        _input = GetComponent<CustomInputManager>();
        _animator = GetComponent<Animator>();
        _attackPower = _playerModel.GetAttackPower();
        _attackRange = _playerModel.GetAttackRange();
    }

    /// <summary>
    /// attack
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(_input.BaseAttackButton))
        {
            Attack();
        }
        if (_comboTime > 0)
        {
            _comboTime -= Time.deltaTime * 3.0f;
        }
        else if (_comboTime <= 0)
        {
            _comboTime = 0;
            _comboEnder = false;
            _comboEnd = false;
        }
    }

    private void Attack()
    {
        if (_playerModel._aim == false)
        {
            _sword.VisibleOnAttack();

            if (_comboEnd == true) return;
            if (_comboEnder == true)
            {
                if (_comboTime > 0)
                {
                    _animator.SetTrigger("ComboEnder");
                    _comboTime = 0;
                    _comboEnder = false;
                    _comboEnd = true;
                    RayCastAttack();
                }
            }
            else
            {
                _animator.SetTrigger("Attack");
                _comboTime = _maxComboTime;
                _comboEnder = true;
                RayCastAttack();
            }
        }
        else if (_playerModel._aim == true)
        {
            Quaternion Rotation = Camera.main.transform.rotation;
            GameObject obj = Instantiate(_knife.gameObject, _knifeStartTransform.position, Rotation);
            obj.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * _knifeSpeed, ForceMode.Impulse);
        }
    }

    private void RayCastAttack()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _attackRange, _layerMask) && !hit.collider.isTrigger && hit.collider.GetComponent<MonsterController>() != null)
        {
            new WaitForSeconds(0.5f);
            hit.collider.GetComponent<MonsterController>().GetDamage(_attackPower);
        }
    }
}