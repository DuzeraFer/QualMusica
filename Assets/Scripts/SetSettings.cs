using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    public Toggle mudo;

    void Start()
    {
        if (PlayerPrefs.GetInt("Mudo") == 1)
        {
            mudo.isOn = true;
            AudioListener.pause = true;
        }

        else if (PlayerPrefs.GetInt("Mudo") == 0)
        {
            mudo.isOn = false;
            AudioListener.pause = false;
        }
    }

    public void ValueChangeCheckMudo()
    {
        PlayerPrefs.SetInt("Mudo", mudo.isOn ? 1 : 0);

        if (PlayerPrefs.GetInt("Mudo") == 1)
        {
            mudo.isOn = true;
            AudioListener.pause = true;
        }

        else if (PlayerPrefs.GetInt("Mudo") == 0)
        {
            mudo.isOn = false;
            AudioListener.pause = false;
        }
    }
}
