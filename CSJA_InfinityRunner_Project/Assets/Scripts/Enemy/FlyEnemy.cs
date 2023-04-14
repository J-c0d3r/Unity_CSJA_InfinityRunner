using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{    
    private Rigidbody2D rig;
    public float speed;

    [SerializeField] private bool isKamikaze;

    void Start()
    {
        base.Start();        
        rig = GetComponent<Rigidbody2D>();
        
        //if(isKamikaze)
            //play audio

    }

    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {        
        if (isKamikaze)
        {
            base.receiveDmg = health;
            base.OnTriggerEnter2D(collision);
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
