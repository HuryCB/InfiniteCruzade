using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    public AudioSource gameSound;

    [SerializeField]
    public AudioSource playerJumpSound;
    public AudioSource earthQuakeSound;
    // Start is called before the first frame update
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void GameSound()
    {
        gameSound.Play();
    }

    public static void Play(AudioSource audio)
    {
        audio.Play();
    }

    public static void Stop(AudioSource audio)
    {
        if(audio == null){
            return;
        }
        if (audio.isPlaying)
        {
            audio.Stop();
        }

    }

}
