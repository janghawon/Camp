using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SpeedTest : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StringDemoFunc();
        }
    }

    private void StringDemoFunc()
    {
        string s = "";
        StringBuilder sb = new StringBuilder();
        
        Debug.Log($"StartTime : {DateTime.Now.ToLongTimeString()}");

        for(int i = 0; i < 100000; i++)
        {
            //s += "Hi ";
            sb.Append("Hi ");
        }
        Debug.Log($"EndTime : {DateTime.Now.ToLongTimeString()}");
        Debug.Log(sb.ToString());
    }
}
