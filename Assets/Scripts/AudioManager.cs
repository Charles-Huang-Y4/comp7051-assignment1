using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public AudioSource audio;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Play() {
        audio.Play();
    }

    public void Stop() {
        audio.Stop();
    }

    public void Pause() {
        audio.Pause();
    }
}
