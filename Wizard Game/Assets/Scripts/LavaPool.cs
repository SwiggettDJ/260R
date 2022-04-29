using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPool : MonoBehaviour
{
    private float lifeTime = 5f;

    private void OnTriggerStay(Collider other)
    {
        //print(other.name);
    }
    private void OnEnable()
    {
        StartCoroutine(KillMySelf());
    }
    
    private IEnumerator KillMySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
