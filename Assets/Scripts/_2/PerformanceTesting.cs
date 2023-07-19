using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    const int numberOfTests = 5000;

    Transform testTrm;

    private void Update()
    {
        PerformanceTest1();
        PerformanceTest2();
        PerformanceTest3();
    }

    private void PerformanceTest1()
    {
        for(int i = 0; i < numberOfTests; i++)
        {
            testTrm = GetComponent<Transform>(); // 제네릭 비용때문에 제일 비쌈
        }
    }

    private void PerformanceTest2()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = (Transform)GetComponent("Transform"); // 스트링으로 가져와서 강제 형변환 한거라 비용이 쌈
            testTrm = GetComponent("Transform").transform; // .도 연산임 .많이 쓰는 건 좀 별로
        }
    }

    private void PerformanceTest3()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = (Transform)GetComponent(typeof(Transform)); // 타입오브 때문에 연산이 한번 더 있음
        }
    }
}
