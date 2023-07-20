using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    public int MaxSpawnCount = 100;
    public float spawnDelay = 0.1f;
    public GameObject cubeObjPrefab;

    private int spawnCount;
    private Vector3 randomPos;
    private GameObject newCube;

    private WaitForSeconds spawnWFS;
    private Coroutine spawnCoVal;

    Stopwatch stopWatch = new Stopwatch();

    private void Start()
    {
        spawnWFS = new WaitForSeconds(spawnDelay);
        spawnCoVal = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(spawnCoVal == null)
            {
                spawnCoVal = StartCoroutine(SpawnCo());
            }
        }
    }

    IEnumerator SpawnCo()
    {
        Debug.Log("큐브 생성 테스트 시작!");
        spawnCount = MaxSpawnCount;

        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        stopWatch.Restart();
        stopWatch.Start();

        while (spawnCount > 0)
        {
            randomPos = new Vector3(Random.value, Random.value, Random.value);
            newCube = Instantiate(cubeObjPrefab, randomPos, Quaternion.identity);
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            newCube.transform.SetParent(this.transform);

            yield return spawnWFS;
            spawnCount--;
        }

        stopWatch.Stop();
        spawnCoVal = null;

        Debug.Log(string.Format("{0}초 걸림", stopWatch.ElapsedMilliseconds / 1000));
    }
}
