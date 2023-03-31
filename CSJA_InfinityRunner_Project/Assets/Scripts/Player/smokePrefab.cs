using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokePrefab : MonoBehaviour
{
    public Player smokePoint;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        smokePoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        int num = Random.Range(0, 2);
        anim.SetInteger("smokes", num);

        float numTime = Random.Range(0.05f, 0.16f);
        Destroy(gameObject, numTime);
    }
    
    void Update()
    {
        transform.position = smokePoint.smokePoint.position;    
    }
}
