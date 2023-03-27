using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;

    public Transform cam;

    public float parallaxFactor;


    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float reposition = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (reposition > startPos + length)
        {
            startPos += length;
        }
    }
}
