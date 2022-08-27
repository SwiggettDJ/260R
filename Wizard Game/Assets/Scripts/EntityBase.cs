using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    protected float currentHealth;
    protected Material[] matList;
    protected Material damageMat;

    protected float maxHealth;
    
    // To be called in child's start
    protected void initialize()
    {
        currentHealth = maxHealth;
        GetDamageMaterial();
        foreach (Material mat in matList)
        {
            if (mat.name == "Damage Flash (Instance)")
            {
                damageMat = mat;
            }
        }
    }

    protected virtual void GetDamageMaterial()
    {
        matList = GetComponent<MeshRenderer>().materials;
    }

    public virtual void Damage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine(Flash(.2f));

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
    IEnumerator Flash(float duration)
    {
        if (damageMat.GetFloat("_Opacity") != 1)
        {
            damageMat.SetFloat("_Opacity", 1);
            yield return new WaitForSeconds(duration);
            damageMat.SetFloat("_Opacity", 0);
        }
    }

}
