using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public float offset;

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;
    public List<GameObject> platform = new List<GameObject>();
    private List<Transform> currentPlatform = new List<Transform>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platform.Count; i++)
        {
            Transform p = Instantiate(platform[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            currentPlatform.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatform[platformIndex].GetComponent<Platform>().finalPoint;
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1)
        {
            Recycle(currentPlatform[platformIndex].gameObject);
            // Recycle(currentPlatform[Random.Range(0, platform.Count)].gameObject);
            platformIndex++;

            if (platformIndex > currentPlatform.Count - 1)
            {
                platformIndex = 0;
            }
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, -4.5f);

        if (platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }

        offset += 30f;
    }
}
