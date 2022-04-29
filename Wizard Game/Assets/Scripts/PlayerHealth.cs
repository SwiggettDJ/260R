using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : EntityBase
{
    private void Start()
    {
        maxHealth = 100;
        initialize();
    }

    protected override void Death()
    {
        print("You died!");
    }
}
