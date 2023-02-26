using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping;

    private Rigidbody2D rigPlayer;
    public Animator playerAnim;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rigPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerAnim.SetBool("jumping", true);
            isJumping = true;
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
