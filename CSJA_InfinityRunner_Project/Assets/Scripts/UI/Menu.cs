using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource audioManager;
    public AudioClip audioBtn;
    public GameObject loadingTxtObj;
    public Text loadingTxt;    


    private void Start()
    {
        audioManager = GetComponent<AudioSource>();
        loadingTxt = loadingTxtObj.GetComponent<Text>();        
    }

    public void BtnStartGame()
    {
        audioManager.PlayOneShot(audioBtn);
        //SceneManager.LoadScene(1);
        StartCoroutine(LoadSceneAsync(1));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneId);

        loadingTxtObj.SetActive(true);

        while (!op.isDone)
        {
            //loadingTxt.text = Mathf.Clamp(op.progress, 0.0f, 100.0f) + "%";
            loadingTxt.text = Mathf.Clamp01(op.progress / 0.9f) * 100 + "%";

            yield return null;
        }

    }

    public void FullScreeen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
