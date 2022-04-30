using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : EntityBase
{
    public GameAction sendHealthAction;
    public GameAction gameOverAction;
    private void Start()
    {
        maxHealth = 100;
        initialize();
    }

    public override void Damage(float damage)
    {
        currentHealth -= damage;
        sendHealthAction.RaiseAction(currentHealth);
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    protected override void Death()
    {
        gameOverAction.raiseNoArgs();
    }
    
}
