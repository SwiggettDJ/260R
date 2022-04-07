using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleSpell : SpellBase
{
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
}
