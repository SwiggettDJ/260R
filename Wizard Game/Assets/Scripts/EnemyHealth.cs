using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityBase
{
    public float setMaxHealth;

    private void Start()
    {
        maxHealth = setMaxHealth;
        initialize();
    }
}
