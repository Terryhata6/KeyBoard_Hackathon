using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBotInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _Particles;
    //[SerializeField] private Transform _particlePosition; //позиция врага
    private void FixedUpdate()
    {

        StartCoroutine(ParticleInstantiate());
    }
    private IEnumerator ParticleInstantiate()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(_Particles, gameObject.transform.position, Quaternion.identity);
    }
    
    
}
