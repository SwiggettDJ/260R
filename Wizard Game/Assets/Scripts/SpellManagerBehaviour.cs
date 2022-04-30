using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagerBehaviour : MonoBehaviour
{

    public List<SpellBase> spells;
    private SpellBase equippedSpell;
    private float timeOfLastShot;
    private SpellBase firedSpell;
    private int simpleDamageUp;
    private int simpleRateUp;
    private int lavaDamageUp;
    private int lavaChanceUp;


    private void Start()
    {
        equippedSpell = spells[0];
        timeOfLastShot = 0f;
    }

    public void Cast()
    {
        if (Time.time - timeOfLastShot >= equippedSpell.GetFireRate())
        {
            firedSpell = Instantiate(equippedSpell, transform.position, transform.rotation);
            SimpleSpell temp = firedSpell.GetComponent<SimpleSpell>();
            if (temp != null)
            {
                for (int i = 0; i < simpleDamageUp; i++)
                {
                    temp.Upgrade(0);
                }
                for (int i = 0; i < simpleRateUp; i++)
                {
                    temp.Upgrade(1);
                }
            }
            LavaSpell lavaTemp = firedSpell.GetComponent<LavaSpell>();
            if(lavaTemp != null)
            {

                for (int i = 0; i < lavaDamageUp; i++)
                {
                    lavaTemp.puddleDamageUp++;
                }
                for (int i = 0; i < lavaChanceUp; i++)
                {
                    lavaTemp.UpgradeSpawnRate();
                }
            }


            timeOfLastShot = Time.time;
        }
        
    }

    public void Swap()
    {
        int i = spells.IndexOf(equippedSpell);
        if (i == spells.Count - 1)
        {
            equippedSpell = spells[0];
        }
        else
        {
            equippedSpell = spells[i + 1];
        }
        
        //reset so we dont carry over fire delay from spells
        timeOfLastShot = 0f;
    }

    public void UpgradePlusOne(int id)
    {
        if (id == 0)
        {
            simpleDamageUp++;
        }
        if (id == 1)
        {
            simpleRateUp++;
        }
        if (id == 2)
        {
            lavaDamageUp++;
        }
        if (id == 3)
        {
            lavaChanceUp++;
        }
    }
}
