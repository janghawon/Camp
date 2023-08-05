using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class CollectionTest : MonoBehaviour
{
    const int numberOfTests = 10000;

    int[] inventory = new int[numberOfTests];
    Dictionary<int, int> inventoryDic = new Dictionary<int, int>();
    List<int> inventoryList = new List<int>();
    HashSet<int> inventroyHash = new HashSet<int>();

    private void Start()
    {
        AddValueArray();
        AddValueInDic();
        AddValueInList();
        AddValueInHash();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PrintValuesInArray();
            PrintValuesInDic();
            PrintValuesInHash();
            PrintValuesInList();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            ContainsValuesInArray();
            ContainsValuesInDict();
            ContainsValuesInList();
            ContainsValuesInHash();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            RemoveValuesInArray();
            RemoveValuesInDict();
            RemoveValuesInList();
            RemoveValuesInHash();
        }
    }

    void RemoveValuesInArray()
    {
        int searchValue = 5000;
       // inventory.Where(i => i != searchValue);

        int[] temp = new int[inventory.Length - 1];
        int tempCOunt = 0;

        for(int i = 0; i < inventory.Length; i++)
        {
            if(i != searchValue)
            {
                temp[tempCOunt] = inventory[i];
                tempCOunt++;
            }
        }
        inventory = temp;
    }

    
    void RemoveValuesInDict()
    {
        int searchValue = 5000;
        bool found = inventoryDic.Remove(searchValue);
    }

    void RemoveValuesInList()
    {
        int searchValue = 5000;
        bool found = inventoryList.Remove(searchValue);
    }

    void RemoveValuesInHash()
    {
        int searchValue = 5000;
        bool found = inventroyHash.Remove(searchValue);
    }

    #region 값확인
    private void ContainsValuesInArray()
    {
        int searchvalue = 5000;
        bool bFound = false;

        for(int i = 0; i < searchvalue; i++)
        {
            if(inventory[i] == searchvalue)
            {
                bFound = true;
                break;
            }
        }
    }
    
    private void ContainsValuesInDict()
    {
        int searchvalue = 5000;

        bool bFound = inventoryDic.ContainsKey(searchvalue);
    }

    private void ContainsValuesInList()
    {
        int searchvalue = 5000;

        bool bFound = inventoryList.Contains(searchvalue);
    }

    private void ContainsValuesInHash()
    {
        int searchvalue = 5000;
        bool bFound = inventroyHash.Contains(searchvalue);
    }
    #endregion

    #region 값 프린트
    private void PrintValuesInArray()
    {
        foreach(int i in inventory)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInDic()
    {
        foreach(KeyValuePair<int, int> i in inventoryDic)
        {
            Debug.Log(i.Value);
        }
    }

    private void PrintValuesInList()
    {
        foreach(int i in inventoryList)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInHash()
    {
        foreach(int i in inventroyHash)
        {
            Debug.Log(i);
        }
    }
    #endregion

    #region 값추가
    private void AddValueArray()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            inventory[i] = Random.Range(10, 100);
        }
    }

    private void AddValueInDic()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventoryDic.Add(i, Random.Range(10, 100));
        }
    }

    private void AddValueInList()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventoryList.Add(Random.Range(10, 100));
        }
    }

    private void AddValueInHash()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            inventroyHash.Add(Random.Range(10, 100));
        }
    }
    #endregion
}
