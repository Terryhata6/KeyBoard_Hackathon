using UnityEngine;

public class MonsterModel : MonoBehaviour
{
    public bool IsDead = false;

    [SerializeField] private float _hp;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _speed;
    [SerializeField] private float _rangeOfView;
    [SerializeField] private float _rangeOfAttack;

    public void GetDamage(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            _hp = 0;
            IsDead = true;
        }

    }

    public float GetAttackPower()
    {
        return _attackPower;
    }
    public float GetSpeed()
    {
        return _speed;
    }
    public float GetRangeOfView()
    {
        return _rangeOfView;
    }
    public float GetRangeOfAttack()
    {
        return _rangeOfAttack;
    }
}