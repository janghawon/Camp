using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyListCreator : MonoBehaviour
{
    public int numberOfLists;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreatList();
        }
    }

    void CreatList()
    {
        for(int i = 0; i < numberOfLists; i++)
        {
            List<string> nameList = new List<string>(numberOfLists);
        }
    }
}
