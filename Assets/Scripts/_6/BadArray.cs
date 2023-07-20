using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadArray : MonoBehaviour
{
    public float[] randResultVal;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            randResultVal = RandomList(10000);
        }
    }

    private float[] RandomList(int v)
    {
        float[] arr = new float[v];
        for (int i = 0; i < v; i++)
        {
            arr[i] = Random.value;
        }
        return arr;
    }
}
