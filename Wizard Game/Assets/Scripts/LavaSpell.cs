using System.Collections.Generic;
using UnityEngine;


public class LavaSpell : SpellBase
{
    private int puddleChance;
    public GameObject lavaPuddle;

    private void Start()
    {
        puddleChance = 3;
        damage = 20;
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
                Instantiate(lavaPuddle, hit.point, transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }

}
