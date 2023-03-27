using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float speed;
    public float offset;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 newCamPos = new Vector3(player.position.x + offset, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, speed * Time.deltaTime);
    }
}
