using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    protected float currentHealth;

    protected float maxHealth;
    // Start is called before the first frame update
    protected void initialize()
    {
        currentHealth = maxHealth;
    }

    public virtual void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

}
