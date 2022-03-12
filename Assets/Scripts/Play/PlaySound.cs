using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlaySound : MonoBehaviour
{
    public AudioClip[] audios;
    AudioClip selectedAudio;
    public AudioSource audioSource;
    PersistentManagerScript persistentManager;

    private void Start()
    {
        persistentManager = GameObject.Find("PersistentManager").GetComponent<PersistentManagerScript>();
        audios = Resources.LoadAll<AudioClip>("Songs");

        foreach (var item in audios)
        {
            if (item.name == persistentManager.actualLevel.ToString())
            {
                selectedAudio = audios[persistentManager.actualLevel];
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
            case 5:
                PlaySound5();
                break;
            default:
                break;
        }
    }

    void PlaySound1()
    {
        Debug.Log("Play sound 1");
        StopAllCoroutines();
        StartCoroutine(PlaySoundInterval(2.5f));
    }

    void PlaySound2()
    {
        Debug.Log("Play sound 2");
        StopAllCoroutines();
        StartCoroutine(PlaySoundInterval(5f));
    }

    void PlaySound3()
    {
        Debug.Log("Play sound 3");
        StopAllCoroutines();
        StartCoroutine(PlaySoundInterval(7.5f));
    }

    void PlaySound4()
    {
        Debug.Log("Play sound 4");
        StopAllCoroutines();
        StartCoroutine(PlaySoundInterval(10f));
    }

    void PlaySound5()
    {
        Debug.Log("Play sound 5");
        StopAllCoroutines();
        StartCoroutine(PlaySoundInterval(selectedAudio.length));
    }


    IEnumerator PlaySoundInterval(float seconds)
    {
        audioSource.Stop();
        audioSource.time = 0f;
        audioSource.PlayOneShot(selectedAudio);

        yield return new WaitForSeconds(seconds);

        audioSource.Stop();
    }
}
