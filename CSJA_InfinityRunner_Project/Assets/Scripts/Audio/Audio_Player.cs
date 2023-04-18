using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip player_shoot;
    public AudioClip player_shootSS;
    public AudioClip player_die;
    //public AudioClip player_jetpack;
    public AudioClip player_hurt;
    public AudioClip powerUp_Life;
    public AudioClip powerUp_SS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        audioS.PlayOneShot(clip, volume);
    }
}
