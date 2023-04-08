using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Player player;
    public int health;
    public int damage;

    protected int receiveDmg = 2;

    public GameObject explosionDeath;

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            //play audio
            Destroy(gameObject);
            GameObject e = Instantiate(explosionDeath, transform.position, transform.rotation);
            Destroy(e, 0.5f);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.GetComponent<Projectile>().OnHit();
            ApplyDamage(other.GetComponent<Projectile>().damage);
        }

        if (other.CompareTag("supershoot"))
        {            
            ApplyDamage(other.GetComponent<Projectile>().damage);
        }

        if (other.CompareTag("Player"))
        {
            player.OnHit(damage);
            ApplyDamage(receiveDmg);
        }

    }
}
