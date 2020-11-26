using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterModel _enemy;

    private void Start()
    {
        _enemy = GetComponent<MonsterModel>();
    }

    public void GetDamage(float damage)
    {
        _enemy.GetDamage(damage);

        //TODO animation
    }
}
