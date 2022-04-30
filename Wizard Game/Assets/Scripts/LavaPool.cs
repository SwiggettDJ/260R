using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPool : MonoBehaviour
{
    private float damage = 5f;
    private float lifeTime = 5f;
    
    private void OnTriggerStay(Collider other)
    {
        EnemyHealth enemyHP = other.GetComponent<EnemyHealth>();
        if(enemyHP != null)
        {
            enemyHP.Damage(damage * Time.deltaTime);
        }
        EnemyController enemy = other.GetComponent<EnemyController>();
        if(enemy != null)
        {
            enemy.SetSpeed(enemy.speed/2);
        }
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
    
    public void UpgradeLavaDamage()
    {
        damage += 5f;
    }
}
