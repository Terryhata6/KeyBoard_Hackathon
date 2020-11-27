using UnityEngine;


public class IdleDissolveKnifeController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float _cutoffSpeed = 1.0f;
    [SerializeField] private float _attackPower = 50.0f;
    private float _cutoff = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if( _cutoff > 0.0f )
        {
            _cutoff -= Time.deltaTime * _cutoffSpeed;
            meshRenderer.material.SetFloat("_Cutoff", _cutoff);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MonsterController>() != null) 
        { 
            other.GetComponent<MonsterController>().GetDamage(_attackPower);
            Destroy(gameObject);
        }
    }

}
