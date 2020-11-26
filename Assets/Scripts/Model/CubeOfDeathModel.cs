using UnityEngine;

public class CubeOfDeathModel : MonoBehaviour
{
    private MonsterModel _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerParametersModel>())
        {
            _enemy = GetComponentInParent<MonsterModel>();
            other.GetComponent<PlayerParametersModel>().GetDamage(_enemy.GetAttackPower());
        }
    }
}
