using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleSpell : SpellBase
{
    private float currentSpeed;
    private float acceleration;
    private float setDamage = 15f;
    private float setFireRate = .2f;
    private void Start()
    {
        currentSpeed = speed * .4f;
        acceleration = speed * 2;
        damage = setDamage;
        fireRate = setFireRate;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        currentSpeed += acceleration * Time.deltaTime;
    }

    public void Upgrade(int statSlot)
    {
        if (statSlot == 0)
        {
            setDamage += 5f;
        }

        if (statSlot == 1)
        {
            setFireRate -= .05f;
            if (setFireRate <= 0)
            {
                setFireRate = 0;
            }
        }

    }
}
