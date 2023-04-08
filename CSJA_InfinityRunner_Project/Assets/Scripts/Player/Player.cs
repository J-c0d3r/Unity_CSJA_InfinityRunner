using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpForce;
    private bool isJumping;
    private int qtySuperShoot = 0;

    private bool recovery;

    private float shootDelay = 0.1f;
    private float timeShoot;

    private SpriteRenderer spriteRenderer;
    private Collider2D coll;
    private Rigidbody2D rigPlayer;
    public Animator playerAnim;
    public GameObject bulletPrefab;
    public GameObject superShootPrefab;
    public Transform firePoint;
    public Transform superShootPoint;
    public GameObject explosionDeath;  
    
    public smoke smoke;
    public Transform smokePoint;

    public GameObject collectedFX;

    public GameObject ssBtn;

    void Start()
    {       
        rigPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<Collider2D>();        
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SuperShoot();
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

    public void SuperShoot()
    {
        if (qtySuperShoot >= 1)
        {
            Instantiate(superShootPrefab, superShootPoint.position, superShootPoint.rotation);
            qtySuperShoot--;
            ssBtn.SetActive(false);
        }
    }

    public void OnJump()
    {
        smoke.createSmoke();
        rigPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        playerAnim.SetBool("jumping", true);       
        isJumping = true;
    }

    private void IncreaseQtySuperShoot()
    {
        if (qtySuperShoot == 0)
        {
            qtySuperShoot++;
            ssBtn.SetActive(true);
        }
    }

    public void OnHit(int dmg)
    {
        if (!recovery)
        {                   
            health -= dmg;

            if (health <= 0)
            {
                //play audio    
                GameObject e = Instantiate(explosionDeath, transform.position, transform.rotation);
                Destroy(e, 0.33f);
                coll.enabled = false;
                spriteRenderer.enabled = false;
                GameController.instance.ShowGameOver();
            }
            else
            {
                //play audio    
                playerAnim.SetTrigger("hit");
            }
        }
        else
        {
            StartCoroutine(OnHitCorroutine());
        }
              
    }

    IEnumerator OnHitCorroutine()
    {
        recovery = true;
        yield return new WaitForSeconds(1f);
        recovery = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            playerAnim.SetBool("jumping", false);
            isJumping = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerLife"))
        {
            //play audio
            health += 2;
            Destroy(collision.gameObject, 0.05f);
            GameObject obj = Instantiate(collectedFX, collision.transform.position, collision.transform.rotation);
            Destroy(obj, 0.33f);
        }

        if (collision.CompareTag("powerSS"))
        {
            //play audio
            IncreaseQtySuperShoot();
            Destroy(collision.gameObject, 0.05f);
            GameObject obj = Instantiate(collectedFX, collision.transform.position, collision.transform.rotation);
            Destroy(obj, 0.33f);
        }
    }
}
