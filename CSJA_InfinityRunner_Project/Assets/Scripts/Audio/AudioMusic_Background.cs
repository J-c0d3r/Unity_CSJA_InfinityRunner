using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusic_Background : MonoBehaviour
{
    public bool gameOver;

    public AudioClip[] musicList;
    
    private AudioSource audioSourceMusic;
                
    void Start()
    {
        audioSourceMusic = GetComponent<AudioSource>();                
    }

    private void Update()
    {
        if (!audioSourceMusic.isPlaying && !gameOver)
        {
            audioSourceMusic.clip = musicList[Random.Range(0, musicList.Length)];
            audioSourceMusic.Play();
        }

        if (gameOver)
        {
            audioSourceMusic.Stop();            
        }
    }

    //public void PlaxSFX(AudioClip clip)
    //{
    //    audioSourceMusic.Stop();
    //    audioSourceMusic.PlayOneShot(clip, 1f);
    //}
}
