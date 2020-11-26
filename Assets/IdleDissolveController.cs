using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class IdleDissolveController : MonoBehaviour
{
    private MeshRenderer meshRenderer;    
    [SerializeField]private float _visibilityTime = 0.0f;
    [SerializeField]private float _maxVisibilityTime = 10.0f;    
    [SerializeField]private float _visibilityChargeSpeed = 6.0f;    
    [SerializeField]private float _cutoffSpeed = 1.0f;
    [SerializeField]private bool _standVisibleRecently; //Говорит был ли объект призван недавно и разрешает сделать его видимым
    private float _cutoff = 0.0f;
    private bool _isVisible; //видимый объект?

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _isVisible = false; 
        _standVisibleRecently = true;  
    }


    void Update()
    {
        CutoffExecute();
    }

    public void VisibleOnAttack()
    {
        _standVisibleRecently = true;
    }

    private void CutoffExecute()
    {
        if (_standVisibleRecently == true)
        {
            if (_cutoff > 0f)//где-то здесь проверка на повторную атаку
                _cutoff -= Time.deltaTime * _cutoffSpeed;
            else if (_cutoff <= 0f)
            {
                _cutoff = 0f;
                _standVisibleRecently = false;
                _isVisible = true;
                _visibilityTime = _maxVisibilityTime;
            }
            meshRenderer.material.SetFloat("_Cutoff", _cutoff);
        }
        else if (_isVisible == true)
        {
            if (_visibilityTime > 0)
            {
                _visibilityTime -= Time.deltaTime * _visibilityChargeSpeed;
            }
            else if (_visibilityTime <= 0)
            {
                if (_cutoff < 1.0f)
                {
                    _cutoff += Time.deltaTime * _cutoffSpeed;
                }
                else if (_cutoff >= 1.0f)
                {
                    _cutoff = 1.0f;
                    _isVisible = false;
                }
                meshRenderer.material.SetFloat("_Cutoff", _cutoff);
            }
        }
    }
}
