using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodArray : MonoBehaviour
{
    float[] randResultVal;

    private void Start()
    {
        randResultVal = new float[10000];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RandomList(randResultVal);
        }
    }

    private void RandomList(float[] arratToFill)
    {
        for(int i = 0; i < arratToFill.Length; i++)
        {
            arratToFill[i] = Random.value;
        }
    }
}
