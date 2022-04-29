using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LavaSpell : SpellBase
{
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //public override void OnTriggerEnter (Collider other) {
        //if (!other.CompareTag("Player")){}}

}
