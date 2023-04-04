using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public float offset;

    private Transform player;
    private Transform createPointPlatform;
    private Transform destroyPointPlatform;
    //private int platformIndex;
    public List<GameObject> platform = new List<GameObject>();
    private List<GameObject> currentListPlatform = new List<GameObject>();
    private List<GameObject> newListPlatform = new List<GameObject>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platform.Count; i++)
        {
            int num = Random.Range(0, 4);
            GameObject obj = Instantiate(platform[num], new Vector2(i * 30, -4.5f), transform.rotation);
            currentListPlatform.Add(obj);
            offset += 30f;
        }

        createPointPlatform = currentListPlatform[2].GetComponent<Platform>().finalPoint;
        destroyPointPlatform = currentListPlatform[0].GetComponent<Platform>().finalPoint;

    }


    void Update()
    {
        Move();
    }


    void Move()
    {
        //Destroy
        float distanceToDestroy = player.position.x - destroyPointPlatform.position.x;

        if (distanceToDestroy >= 1)
        {
            if (newListPlatform.Count > 0)
            {
                for (int i = 0; i < platform.Count; i++)
                {
                    Destroy(currentListPlatform[i]);
                }

                currentListPlatform.Clear();
                currentListPlatform.AddRange(newListPlatform);
                newListPlatform.Clear();

            }

            // !!! OLD CODE
            //Recycle(currentPlatform[platformIndex].gameObject);            
            //platformIndex++;

            //if (platformIndex > currentPlatform.Count - 1)
            //{
            //    platformIndex = 0;
            //}
        }


        //Create
        float distanceToCreate = player.position.x - createPointPlatform.position.x;

        if (distanceToCreate >= 1)
        {
            for (int i = 0; i < platform.Count; i++)
            {
                int num = Random.Range(0, 4);
                GameObject obj = Instantiate(platform[num], new Vector2(offset, -4.5f), transform.rotation);
                newListPlatform.Add(obj);
                offset += 30f;
            }

            createPointPlatform = newListPlatform[2].GetComponent<Platform>().finalPoint;
            destroyPointPlatform = newListPlatform[0].GetComponent<Platform>().finalPoint;
        }


    }

    // !!! OLD CODE
    //public void Recycle(GameObject platform)
    //{
    //    platform.transform.position = new Vector2(offset, -4.5f);

    //    if (platform.GetComponent<Platform>().spawnObj != null)
    //    {
    //        platform.GetComponent<Platform>().spawnObj.Spawn();
    //    }

    //    offset += 30f;
    //}
}
