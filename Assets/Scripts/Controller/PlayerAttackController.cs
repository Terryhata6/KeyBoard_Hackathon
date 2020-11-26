using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private IdleDissolveController _sword;
    private PlayerParametersModel _playerModel;
    private CustomInputManager _input;

    private float _attackPower;
    private float _attackRange;
    private bool _isAttacking;

    private void Start()
    {
        _playerModel = GetComponent<PlayerParametersModel>();
        _input = GetComponent<CustomInputManager>();
        _attackPower = _playerModel.GetAttackPower();
        _attackRange = _playerModel.GetAttackRange();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_input.BaseAttackButton))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_isAttacking) return;
        _sword.VisibleOnAttack();
        //_isAttacking = true;

        //Ray straight out of the center of the camera
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _attackRange, _layerMask) && !hit.collider.isTrigger && hit.collider.GetComponent<MonsterController>() != null)
        {
            hit.collider.GetComponent<MonsterController>().GetDamage(_attackPower);
        }

        //_isAttacking = false;
    }
}