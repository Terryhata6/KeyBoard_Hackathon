using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleNanoBotsTransition : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] [Range(1.0f, 5.0f)] private float MoveAccelerationSpeed;
    [SerializeField] private float MoveSpeedMax;
    [SerializeField] [Range(0f, 3.0f)] private float TimeToDestroy;
    private IdleLightController _idleLightToolBox;
    private Transform _TargetTransform;
    //private Transform _playerTransform;

    public void Start()
    {
        _idleLightToolBox = FindObjectOfType<IdleLightController>();
        _TargetTransform = FindObjectOfType<HandToolType>().transform;

    }

    // Update is called once per frame
    public void Update()
    {
        if (MoveSpeed < MoveSpeedMax)
        {
            MoveSpeed += MoveAccelerationSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, _TargetTransform.position) <= 0.1f) //ОЧЕНЬ ДОРОГО transform.position == _TargetTransform.position
        {
            DestroyAndGetNano();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _TargetTransform.position, MoveSpeed * Time.deltaTime);
            //Destroy(gameObject, 10f);
        }
    }

    private void DestroyAndGetNano()
    {
        Destroy(gameObject, TimeToDestroy);
        _idleLightToolBox.GiveMoreLight();
    }
}
