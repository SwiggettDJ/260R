using System.Collections.Generic;
using UnityEngine;


public class LavaSpell : SpellBase
{
    private int puddleChance;
    public GameObject lavaPuddle;

    private void Start()
    {
        puddleChance = 10;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            spellEffect.Stop();
            Instantiate(onHitEffect, transform.position, transform.rotation * Quaternion.Euler(180, 0, 0));
            other.attachedRigidbody.AddExplosionForce(knockback, transform.position, 20);
            transform.DetachChildren();
            
            //Chance to spawn a lava puddle on impact
            int numberRoll = Random.Range(1, 11);
            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50, LayerMask.GetMask("Ground"));
            if (numberRoll <= puddleChance)
            {
                Instantiate(lavaPuddle, hit.point, transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }

}
