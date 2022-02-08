using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour
{
    AudioClip[] audios;
    AudioClip selectedAudio;
    public AudioSource audioSource;

    private void Awake()
    {
        audios = Resources.LoadAll<AudioClip>("Resources");
    }

    private void Start()
    {
        foreach (var item in audios)
        {
            if (item.name == (SceneManager.GetActiveScene().buildIndex - 1).ToString())
            {
                selectedAudio = audios[(SceneManager.GetActiveScene().buildIndex - 1)];
            }
        }
    }

    public void selectPlaySound(int rounds)
    {
        switch (rounds)
        {
            case 1:
                PlaySound1();
                break;
            case 2:
                PlaySound2();
                break;
            case 3:
                PlaySound3();
                break;
            case 4:
                PlaySound4();
                break;
            default:
                break;
        }
    }

    void PlaySound1()
    {
        PlaySoundInterval(2.5f);
    }

    void PlaySound2()
    {
        PlaySoundInterval(4f);
    }

    void PlaySound3()
    {
        PlaySoundInterval(5.5f);
    }

    void PlaySound4()
    {
        PlaySoundInterval(10f);
    }

    void PlaySoundInterval(float toSeconds)
    {
        audioSource.time = 0f;
        audioSource.PlayOneShot(selectedAudio);
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - 0f));
    }
}
