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
            testTrm = GetComponent<Transform>(); // ���׸� ��붧���� ���� ���
        }
    }

    private void PerformanceTest2()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = (Transform)GetComponent("Transform"); // ��Ʈ������ �����ͼ� ���� ����ȯ �ѰŶ� ����� ��
            testTrm = GetComponent("Transform").transform; // .�� ������ .���� ���� �� �� ����
        }
    }

    private void PerformanceTest3()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            testTrm = (Transform)GetComponent(typeof(Transform)); // Ÿ�Կ��� ������ ������ �ѹ� �� ����
        }
    }
}
