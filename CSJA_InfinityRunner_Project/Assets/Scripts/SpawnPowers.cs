using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowers : MonoBehaviour
{
    public GameObject powerLifePrefab;
    public GameObject powerSSPrefab;
    private float timeCountH;
    public float spawnTimeH;

    private float timeCountSS;
    public float spawnTimeSS;

    public List<Transform> pointList = new List<Transform>();


    void Update()
    {

        //Heart
        timeCountH += Time.deltaTime;

        if (timeCountH >= spawnTimeH)
        {
            int num = Random.Range(0, 3);
            Instantiate(powerLifePrefab, pointList[num].position, transform.rotation);
            timeCountH = 0;

            spawnTimeH = Random.Range(15f, 20f);
        }

        //SuperShoot
        timeCountSS += Time.deltaTime;

        if (timeCountSS >= spawnTimeSS)
        {
            int num = Random.Range(0, 3);
            Instantiate(powerSSPrefab, pointList[num].position, transform.rotation);
            timeCountSS = 0;

            spawnTimeSS = Random.Range(20f, 30f);
        }
    }
}
