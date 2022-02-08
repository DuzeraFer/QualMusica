using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInicial : MonoBehaviour
{
    ChangeScenes changeScenes;

    private void Start()
    {
        changeScenes = GetComponent<ChangeScenes>();    
    }

    public void StartGame()
    {
        changeScenes.StartScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
