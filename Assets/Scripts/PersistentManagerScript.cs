using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    public int Points = 0;
    public int actualLevel = 0;
    public int lastLevel = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        Debug.Log(Points);
        Debug.Log(actualLevel);
    }

    public void OnScenesChange(int _points)
    {
        Points += _points;
        actualLevel++;

        Debug.Log(Points);
        Debug.Log(actualLevel);
    }
}
