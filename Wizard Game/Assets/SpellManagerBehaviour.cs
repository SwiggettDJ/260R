using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spell1;
    public GameObject firePoint;
    
    public void Cast()
    {
        Instantiate(spell1, firePoint.transform.position, firePoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
