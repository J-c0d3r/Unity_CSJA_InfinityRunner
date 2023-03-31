using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static GameController instance;
    public Player player;

    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void playerShoot()
    {
        player.OnShoot();
    }

    public void playerJump()
    {
        player.OnJump();
    }

    public void ShowGameOver()
    {
        StartCoroutine(ShowGameOverCoroutine());        
    }

    IEnumerator ShowGameOverCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


}
