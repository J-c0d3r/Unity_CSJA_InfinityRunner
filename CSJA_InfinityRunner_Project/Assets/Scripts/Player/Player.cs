using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    public float speed;
    public float jumpForce;
    private bool isDead;
    //private bool isJumping;
    //private bool isFlying;
    private int qtySuperShoot = 0;

    private bool recovery;

    private float shootDelay = 0.1f;
    private float timeShoot;

    private float timeCountDiff;
    public float maxTimeDiff;

    private float diffSpeedBulletPlayer;
    private float diffSpeedSSPlayer;

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

    private Audio_Player audioManager;

    void Start()
    {
        rigPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        audioManager = GetComponent<Audio_Player>();

        diffSpeedBulletPlayer = bulletPrefab.GetComponent<Projectile>().speed - speed;
        diffSpeedSSPlayer = superShootPrefab.GetComponent<Projectile>().speed - speed;
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

        IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
        timeCountDiff += Time.deltaTime;
        if (timeCountDiff >= maxTimeDiff)
        {
            timeCountDiff = 0;
            speed = speed * 1.15f;
        }
    }

    public void OnShoot()
    {
        if (!isDead)
        {
            timeShoot += Time.deltaTime;
            if (timeShoot >= shootDelay)
            {
                audioManager.PlaySFX(audioManager.player_shoot, 0.7f);
                GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                obj.GetComponent<Projectile>().speed = speed + diffSpeedBulletPlayer;
                timeShoot = 0f;
            }
        }
    }

    public void SuperShoot()
    {
        if (!isDead)
        {
            if (qtySuperShoot >= 1)
            {
                audioManager.PlaySFX(audioManager.player_shootSS, 1f);
                GameObject obj = Instantiate(superShootPrefab, superShootPoint.position, superShootPoint.rotation);
                obj.GetComponent<Projectile>().speed = speed + diffSpeedBulletPlayer;
                qtySuperShoot--;
                ssBtn.SetActive(false);
            }
        }
    }

    public void OnJump()
    {
        if (!isDead)
        {
            //isFlying = true;
            smoke.createSmoke();
            rigPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerAnim.SetBool("jumping", true);
            //isJumping = true;
        }
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
                audioManager.PlaySFX(audioManager.player_die, 1f);
                GameObject e = Instantiate(explosionDeath, transform.position, transform.rotation);
                Destroy(e, 0.33f);
                coll.enabled = false;
                spriteRenderer.enabled = false;
                isDead = true;
                GameController.instance.ShowGameOver();
            }
            else
            {
                audioManager.PlaySFX(audioManager.player_hurt, 1);
                playerAnim.SetTrigger("hit");

                StartCoroutine(OnHitCorroutine());
            }
        }
    }

    IEnumerator OnHitCorroutine()
    {
        recovery = true;
        yield return new WaitForSeconds(1f);
        recovery = false;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            playerAnim.SetBool("jumping", false);
            //isJumping = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerLife"))
        {
            audioManager.PlaySFX(audioManager.powerUp_Life, 1);
            if (health < maxHealth)
            {
                for (int i = 1; i <= 10; i++)
                {
                    health++;
                    if (health == maxHealth)
                    {
                        break;
                    }
                }
            }

            Destroy(collision.gameObject, 0.05f);
            GameObject obj = Instantiate(collectedFX, collision.transform.position, collision.transform.rotation);
            Destroy(obj, 0.33f);
        }

        if (collision.CompareTag("powerSS"))
        {
            audioManager.PlaySFX(audioManager.powerUp_SS, 1);
            IncreaseQtySuperShoot();
            Destroy(collision.gameObject, 0.05f);
            GameObject obj = Instantiate(collectedFX, collision.transform.position, collision.transform.rotation);
            Destroy(obj, 0.33f);
        }
    }
}
