using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBenchMarking : MonoBehaviour
{
    public int numberOfSpheres = 100;
    private Transform[] spheres;

    private void Start()
    {
        spheres = new Transform[numberOfSpheres];
        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sobj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer rend = (Renderer)sobj.GetComponent("Renderer");
            rend.material = new Material(Shader.Find("Specular"));
            rend.material.color = Color.red;
            sobj.transform.position = Random.insideUnitSphere * 20;

            spheres[i] = sobj.transform;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < numberOfSpheres; i++)
            {
                spheres[i].Translate(0, 0, 1f);
            }
        }
    }
}
