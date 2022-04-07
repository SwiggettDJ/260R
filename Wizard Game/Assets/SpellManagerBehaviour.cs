using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spell1;

    public void Cast()
    {
        Instantiate(spell1, transform.position, transform.rotation);
    }
}
