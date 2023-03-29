using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private float timeCount;
    public float spawnTime;

    public List<GameObject> enemiesList = new List<GameObject>();

    void Start()
    {
        SpawnEnemy();
    }


    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTime)
        {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(-2.5f, 2.6f), 0), transform.rotation);
    }

}
