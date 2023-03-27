using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpForce;
    private bool isJumping;

    private Rigidbody2D rigPlayer;
    public Animator playerAnim;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        rigPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigPlayer.velocity = new Vector2(speed, rigPlayer.velocity.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }

    public void OnShoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnJump()
    {
        rigPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        playerAnim.SetBool("jumping", true);
        isJumping = true;
    }

    public void OnHit(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            playerAnim.SetBool("jumping", false);
            isJumping = false;
        }
    }
}
