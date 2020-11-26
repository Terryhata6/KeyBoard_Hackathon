using UnityEngine;

public class PlayerParametersModel : MonoBehaviour
{
    public bool IsDead = false;

    [Header("Health")]
    [SerializeField] private float _currentHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _speedRegenHP;
    [SerializeField] private float _maxRegenHp;

    [Header("Stamina")]
    [SerializeField] private float _currentStamina;
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _speedRegenStamina;

    [Header("Attack")]
    [SerializeField] private float _attackPower;
    [SerializeField] private float _attackRange;


    private void Update()
    {
        if (_currentHP < _maxRegenHp)
        {
            RegenHP();
        }
        if (_currentStamina < _maxStamina)
        {
            RegenStamina();
        }
    }

    private void RegenHP()
    {
        _currentHP += _speedRegenHP * Time.deltaTime;

        if (_currentHP >= _maxRegenHp)
        {
            _currentHP = _maxRegenHp;
        }
    }

    private void RegenStamina()
    {
        _currentStamina += _speedRegenStamina * Time.deltaTime;

        if (_currentStamina > _maxStamina)
        {
            _currentStamina = _maxStamina;
        }
    }

    public float GetCurrentHP()
    {
        return _currentHP;
    }
    public float GetMaxHP()
    {
        return _maxHP;
    }
    public float GetCurrentStamina()
    {
        return _currentStamina;
    }
    public float GetMaxStamina()
    {
        return _maxStamina;
    }

    public void GetDamage(int damage)
    {
        _currentHP -= damage;
        
        if (_currentHP <= 0)
        {
            IsDead = true;
        }
    }

    public void GetHeal(float heal)
    {
        _currentHP += heal;

        if (_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }
    }

    public float GetAttackPower()
    {
        return _attackPower;
    }
    public float GetAttackRange()
    {
        return _attackRange;
    }
}