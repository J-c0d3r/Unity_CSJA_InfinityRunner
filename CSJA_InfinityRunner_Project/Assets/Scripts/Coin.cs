using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;

    public GameObject fxCollected;
    public GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            GameObject go = Instantiate(fxCollected, transform.position, transform.rotation);
            Destroy(go, 0.33f);
            Destroy(gameObject);
            gc.increasePointsPlayer(points);
        }
    }

}
