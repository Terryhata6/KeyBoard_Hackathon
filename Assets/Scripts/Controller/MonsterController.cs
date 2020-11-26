using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterModel _enemy;
    private Animator _animator;
    private MonsterState _state;

    private void Start()
    {
        _enemy = GetComponent<MonsterModel>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void GetDamage(float damage)
    {
        _enemy.GetDamage(damage);

        //TODO animation
    }
}
