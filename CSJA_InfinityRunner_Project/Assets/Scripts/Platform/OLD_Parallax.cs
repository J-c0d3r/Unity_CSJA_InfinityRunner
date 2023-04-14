using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;

    public Transform cam;

    public float parallaxFactor;
    private float tempParallax;
    private float newParallaxFactor;

    public bool canMove;
    public bool isFront;

    private float newPosZ;
    private float oldPosZ;

    void Start()
    {
        startPos = transform.position.x;
        length = 2f * GetComponent<SpriteRenderer>().bounds.size.x;
        tempParallax = parallaxFactor;
    }

    public void Reposition(Transform posBackNext, Transform posFrontNext)
    {
        if(isFront)
        {
            oldPosZ = transform.position.z;
            newPosZ = posBackNext.position.z;
            transform.position = new Vector3(posFrontNext.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(posBackNext.position.x, transform.position.y, transform.position.z);
        }
    }


    void LateUpdate()
    {
        float reposition = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        //if (reposition > startPos + length)
        //{
        //    startPos += length;
        //}

        if (canMove)
        {
            
            if (reposition > startPos + length)
            {
                startPos += length;
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
            }
            parallaxFactor = tempParallax;
        }
        else
        {
            tempParallax = parallaxFactor;
            newParallaxFactor = Mathf.Lerp(parallaxFactor, 0, 1f);
            parallaxFactor = newParallaxFactor;

            if (reposition > startPos + length)
            {
                startPos += 2 * length;
            }
        }
    }
}
