using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int points;
    private float second;
    private int minute;
    private bool wasTimeStarted;
    private bool isPaused;


    public GameObject panelPauseGame;
    public static GameController instance;
    public GameObject gameOverPanel;
    public Player player;
    public AudioMusic_Background audioMusicBG_Manager;
    public AudioSource audioManager;
    public AudioClip audio_GameOver;
    public AudioClip audio_Btn;

    [SerializeField] private Text pointsTxt;
    [SerializeField] private Text secondsTimeTxt;
    [SerializeField] private Text minutesTimeTxt;
    [SerializeField] private Image lifeImg;

    [SerializeField] private Text bestPointsTxt;
    [SerializeField] private Text bestTimeTxt;




    void Start()
    {
        audioManager = GetComponent<AudioSource>();

        instance = this;
        Time.timeScale = 1f;
        wasTimeStarted = true;

        bestPointsTxt.text = PlayerPrefs.GetInt("bestPoints").ToString();
        bestTimeTxt.text = PlayerPrefs.GetInt("minute").ToString("00") + ":" + PlayerPrefs.GetInt("second").ToString("00");

    }

    private void Update()
    {
        if (wasTimeStarted)
        {
            second += Time.deltaTime;
            if (second > 59)
            {
                second = 0;
                minute++;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
                isPaused = !isPaused;
            }
        }

        secondsTimeTxt.text = second.ToString("00");
        minutesTimeTxt.text = minute.ToString("00");

        lifeImg.fillAmount = ((float)player.GetHealth() / (float)player.GetMaxHealth());
        lifeImg.color = new Color32((byte)(140 + (lifeImg.fillAmount * 115)), (byte)(lifeImg.fillAmount * 255), 54, 255);

    }

    public void increasePointsPlayer(int pts)
    {
        points += pts;
        pointsTxt.text = points.ToString();
    }


    public void playerShoot()
    {
        player.OnShoot();
    }

    public void playerSS()
    {
        player.SuperShoot();
    }

    public void playerJump()
    {
        player.OnJump();
    }

    public void ShowGameOver()
    {
        audioMusicBG_Manager.gameOver = true;
        audioManager.PlayOneShot(audio_GameOver);
        wasTimeStarted = false;
        StartCoroutine(ShowGameOverCoroutine());
    }

    IEnumerator ShowGameOverCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;

        if (points > PlayerPrefs.GetInt("bestPoints", points))
        {
            PlayerPrefs.SetInt("bestPoints", points);
        }

        int totalTimeActual = (int)(minute * 60 + second);
        int totalTimePrefs = PlayerPrefs.GetInt("minute") * 60 + PlayerPrefs.GetInt("second");

        if (totalTimeActual > totalTimePrefs)
        {
            PlayerPrefs.SetInt("second", (int)second);
            PlayerPrefs.SetInt("minute", minute);
        }
    }

    public void RestartGame()
    {        
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        audioManager.PlayOneShot(audio_Btn);
        panelPauseGame.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        audioManager.PlayOneShot(audio_Btn);
        panelPauseGame.SetActive(false);
        Time.timeScale = 1f;
    }

}
