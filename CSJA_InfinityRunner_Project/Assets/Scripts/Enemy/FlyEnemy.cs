using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    private Player player;
    private Rigidbody2D rig;
    public float speed;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
    }
}
