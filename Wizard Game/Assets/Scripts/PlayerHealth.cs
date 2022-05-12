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
        sendHealthAction.RaiseAction(currentHealth - damage);
        base.Damage(damage);
    }

    protected override void GetDamageMaterial()
    {
        matList = GetComponentInChildren<SkinnedMeshRenderer>().materials;
    }

    protected override void Death()
    {
        gameOverAction.raiseNoArgs();
    }
    
}
