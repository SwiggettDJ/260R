using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class FloatSO : ScriptableObject
{
    public float value;
    private float iter;

    void Start()
    {
        clear();
    }

    public void Iterate()
    {
        value += iter;
    }
    
    public void clear()
    {
        iter = 1.5f;
        value = 6f;
    }
}
