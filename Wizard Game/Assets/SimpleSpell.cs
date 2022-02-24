using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleSpell : SpellBase
{
    private float knockback = 200f;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnTriggerEnter (Collider other) {
        if (!other.CompareTag("Player"))
        {
            Instantiate(onHitEffect, transform.position,  transform.rotation * Quaternion.Euler(180,0,0));
            other.attachedRigidbody.AddExplosionForce(knockback, transform.position,20);
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
