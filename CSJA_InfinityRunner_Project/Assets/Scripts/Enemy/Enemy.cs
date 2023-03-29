using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Player player;
    public int health;
    public int damage;

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.GetComponent<Projectile>().OnHit();
            ApplyDamage(other.GetComponent<Projectile>().damage);
        }

        if (other.CompareTag("Player"))
        {
            player.OnHit(damage);
            ApplyDamage(2);
        }

    }
}
