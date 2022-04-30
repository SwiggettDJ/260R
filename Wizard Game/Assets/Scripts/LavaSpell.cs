using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LavaSpell : SpellBase
{
    private int puddleChance = 3;
    [NonSerialized] public int puddleDamageUp = 0;
    public LavaPool lavaPuddle;
    private LavaPool puddle;

    private void Start()
    {
        damage = 20f;
        fireRate = 1f;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            base.OnTriggerEnter(other);
            
            //Chance to spawn a lava puddle on impact
            int numberRoll = Random.Range(1, 11);
            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50, LayerMask.GetMask("Ground"));
            if (numberRoll <= puddleChance)
            {
                puddle = Instantiate(lavaPuddle, hit.point, transform.rotation);
                for (int i = 0; i < puddleDamageUp; i++)
                {
                    puddle.UpgradeLavaDamage();
                }
            }

            Destroy(gameObject);
        }
    }
    public void UpgradeSpawnRate()
    {
        puddleChance += 2;

    }

}
