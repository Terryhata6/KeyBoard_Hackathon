using UnityEngine;
using UnityEngine.UI;

public class MonsterModel : MonoBehaviour
{
    public bool IsDead = false;

    [SerializeField] private float _hp;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _attackSpeed;


    private void Update()
    {
        //Debug-------------------------------------
        GetComponentInChildren<Text>().text = $"{_hp}";
        //Debug-------------------------------------
    }

    public void GetDamage(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            IsDead = true;
        }

    }

    public float GetAttackPower()
    {
        return _attackPower;
    }
    public float GetAttackSpeed()
    {
        return _attackSpeed;
    }

}
