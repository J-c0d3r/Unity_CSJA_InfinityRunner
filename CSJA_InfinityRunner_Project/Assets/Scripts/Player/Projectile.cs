using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigProj;
    public float speed;
    public int damage;

    public GameObject expPrefab;


    void Start()
    {
        rigProj = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        rigProj.velocity = Vector2.right * speed;
    }

    public void OnHit()
    {
        GameObject e = Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(e, 1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            OnHit();
        }

    }
}
