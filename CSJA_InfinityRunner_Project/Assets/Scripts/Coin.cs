using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;

    public GameObject fxCollected;
    public GameController gc;
    private AudioSource audioS;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            audioS.Play();
            gc.increasePointsPlayer(points);
            GameObject go = Instantiate(fxCollected, transform.position, transform.rotation);
            Destroy(go, 0.33f);            
            Destroy(gameObject, 0.14f);

        }
    }
}
