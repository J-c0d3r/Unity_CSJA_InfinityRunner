using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpForce;
    private bool isJumping;

    private float shootDelay = 0.1f;
    private float timeShoot;

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

        if (Input.GetKey(KeyCode.Space))
        {
            OnJump();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            OnShoot();
        }        
    }    

    public void OnShoot()
    {
        timeShoot += Time.deltaTime;
        if (timeShoot >= shootDelay)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timeShoot = 0f;
        }
        
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
