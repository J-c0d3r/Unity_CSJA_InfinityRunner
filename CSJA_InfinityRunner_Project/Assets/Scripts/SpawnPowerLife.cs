using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerLife : MonoBehaviour
{
    public GameObject powerLifePrefab;
    private float timeCount;
    public float spawnTime;

    public List<Transform> pointList = new List<Transform>();


    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTime)
        {
            int num = Random.Range(0, 3);
            Instantiate(powerLifePrefab, pointList[num].position, transform.rotation);
            timeCount = 0;

            spawnTime = Random.Range(15f, 20f);
        }
    }
}
