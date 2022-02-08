using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int ActualScene;

    void Start() 
    {
        ActualScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);
        PersistentManagerScript.Instance.actualLevel = PersistentManagerScript.Instance.lastLevel;
    }

    public void NextScene(int _points)
    {
        SceneManager.LoadScene(ActualScene);
        PersistentManagerScript.Instance.OnScenesChange(_points);
    }

    public void MenuScene()
    {
        PersistentManagerScript.Instance.lastLevel = PersistentManagerScript.Instance.actualLevel;
        SceneManager.LoadScene(0);
        PersistentManagerScript.Instance.actualLevel = 0;
    }
}
