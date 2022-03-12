using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesLabel : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI dicaText;
    public TextMeshProUGUI pontosPlayerText;


    public string[] dicas = new string[] { "Vai si, vai si", "Eu quero dormir", "Cansado de apegar" };

    void Start()
    {
        dicaText.text = dicas[PersistentManagerScript.Instance.actualLevel];
        roundText.text = "Round: " + ScenesButton.Rounds;
        pointsText.text = "Points: " + ScenesButton.Pontos;
        pontosPlayerText.text = PersistentManagerScript.Instance.Points.ToString();
    }

    public void checkRound()
    {
        roundText.text = "Round: " + ScenesButton.Rounds;
    }

    public void checkPoint() 
    {
        pointsText.text = "Points: " + ScenesButton.Pontos;
    }
}
