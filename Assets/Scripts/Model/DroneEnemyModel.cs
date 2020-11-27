using UnityEngine;

public class DroneEnemyModel : MonoBehaviour
{
    public bool IsDead;

    [SerializeField] private float _currentHP;
    [SerializeField] private float _speed;
    [SerializeField] private float _viewRange;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _attackRange;
      

    public void GetDamage(float damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            IsDead = true;
        }
    }
    public float GetSpeed()
    {
        return _speed;
    }
    public float GetCurrentHP()
    {
        return _currentHP;
    }
    public float GetAttackPower()
    {
        return _attackPower;
    }
    public float GetAttackRange()
    {
        return _attackRange;
    }
    public float GetViewRange()
    {
        return _viewRange;
    }
}