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
    private void Start()
    {
        currentSpeed = speed * .4f;
        acceleration = speed * 2;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        currentSpeed += acceleration * Time.deltaTime;
    }
}
