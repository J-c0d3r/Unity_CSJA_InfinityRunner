using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource audioManager;
    public AudioClip audioBtn;

    private void Start()
    {
        audioManager = GetComponent<AudioSource>();
    }

    public void BtnStartGame()
    {
        audioManager.PlayOneShot(audioBtn);
        SceneManager.LoadScene(1);
    }
}
