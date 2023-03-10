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
        Instantiate(enemiesList[0], transform.position + new Vector3(0, Random.Range(0f, 3f), 0), transform.rotation);
    }

}
