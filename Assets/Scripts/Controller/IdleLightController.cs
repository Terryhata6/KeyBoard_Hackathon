using UnityEngine;

[RequireComponent(typeof(Light))]
public class IdleLightController : MonoBehaviour
{
    [SerializeField] public float IntensityChangeMulti;
    public float MaxLightInentensity;
    private bool _scaleIntensityUp;
    private bool _scaleIntensityDown;
    public Light LightComp;


    public void Start()
    {
        MaxLightInentensity = 45.0f;
        LightComp = GetComponent<Light>();
        _scaleIntensityDown = false;
        _scaleIntensityUp = false;
    }

    // Update is called once per frame
    public void Update()
    {
        IntencityChanges();
    }

    public void IntencityChanges() 
    {
        if (_scaleIntensityUp == true)
        {
            if (LightComp.intensity < MaxLightInentensity)
            {
                LightComp.intensity += Time.deltaTime * IntensityChangeMulti;
            }
            else
            {
                _scaleIntensityUp = false;
                _scaleIntensityDown = true;
            }
        }
        else if (_scaleIntensityDown == true)
        {
            if (LightComp.intensity > 0)
            {
                LightComp.intensity -= Time.deltaTime * IntensityChangeMulti;
            }
            else
            {
                _scaleIntensityDown = false;
                //_scaleIntensityUp = true;  //Убрать после теста
            }
            if (LightComp.intensity < 0) LightComp.intensity = 0;
        }
    }

    public void GiveMoreLight()
    {
        if (_scaleIntensityUp != true) 
        {
            _scaleIntensityUp = true;
        }
        if (_scaleIntensityDown == true)
        {
            _scaleIntensityDown = false;
            _scaleIntensityUp = true;
        }
            
    }      
}
