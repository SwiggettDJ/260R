using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpellBase> spells;
    private SpellBase equippedSpell;
    private float timeOfLastShot;


    private void Start()
    {
        equippedSpell = spells[0];
        timeOfLastShot = 0f;
    }

    public void Cast()
    {
        if (Time.time - timeOfLastShot >= equippedSpell.fireRate)
        {
            Instantiate(equippedSpell, transform.position,transform.rotation);
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
}
