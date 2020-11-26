using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleNanoBotsTransition : MonoBehaviour
{
    [SerializeField] private Transform TransitionTarget; //Сюда поместить объект с Прибор CP-500
    [SerializeField] private float MoveSpeed;
    [SerializeField] [Range(1.0f, 5.0f)] private float MoveAccelerationSpeed;
    [SerializeField] private float MoveSpeedMax;
    [SerializeField] [Range(0f, 3.0f)] private float TimeToDestroy;
    //private Transform _playerTransform;


    public void Start()
    {
        // _playerTransform = TransitionTarget.transform;
        //var offset = new Vector3(0, 10, 0);

    }


    // Update is called once per frame
    public void Update()
    {
        if (MoveSpeed < MoveSpeedMax)
        {
            MoveSpeed += MoveAccelerationSpeed * Time.deltaTime;
        }
        if (transform.position == TransitionTarget.position)
        {
            Destroy(gameObject, TimeToDestroy);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, TransitionTarget.position, MoveSpeed * Time.deltaTime);
            Destroy(gameObject, 10f);
        }
    }
}
