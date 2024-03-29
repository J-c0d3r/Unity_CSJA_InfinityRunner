using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Player player;
    protected Audio_Player playerAudio;
    public int health;
    public int damage;
    public int points;

    protected int receiveDmg = 2;

    public GameObject explosionDeath;
    public GameController gc;

    private AudioSource audioManager;
    public AudioClip explosionSelf;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<Audio_Player>();
        gc = GameObject.FindObjectOfType<GameController>().GetComponent<GameController>();
        audioManager = GetComponent<AudioSource>();
    }

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            playerAudio.PlaySFX(explosionSelf, 1f);
            Destroy(gameObject);
            GameObject e = Instantiate(explosionDeath, transform.position, transform.rotation);
            Destroy(e, 0.5f);
            gc.increasePointsPlayer(points);
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

        if (other.CompareTag("enemiesBarrier"))
        {
            Destroy(gameObject);
        }
    }
}
