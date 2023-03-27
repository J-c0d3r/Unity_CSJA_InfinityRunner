using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public float throwTime;
    private float throwCount;

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform firePoint;

    void Start()
    {

    }


    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCount = 0f;
        }
    }
}
