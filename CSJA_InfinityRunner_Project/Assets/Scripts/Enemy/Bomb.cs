using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rigBomb;
    private Player player;

    public int damage;
    public float xAxis;
    public float yAxis;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigBomb = GetComponent<Rigidbody2D>();
        rigBomb.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
    }

}
