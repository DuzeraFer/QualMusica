using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScenesButton : MonoBehaviour
{
    public TMP_InputField inputResposta;
    public Button NextDica;
    public Button LastDica;
    public Button FirstDica;

    public string CantorResposta;
    public string MusicaResposta;

    public static int Rounds;
    public static int Pontos;

    public GameObject soundPlayer;
    PlaySound playSound;
    ChangeScenes changeScenes;

    [HideInInspector]
    public string[] Cantor;
    [HideInInspector]
    public string[] Musica;

    void Start()
    {
        playSound = soundPlayer.GetComponent<PlaySound>();
        changeScenes = GetComponent<ChangeScenes>();

        Cantor = new string[] { "MC DAVI", "MC LIVINHO", "MC PEDRINHO" };
        Musica = new string[] { "BIPOLAR", "NA PONTA DO PÉ 2", "CANSEI DE ME APEGAR" };

        Rounds = 1;
        Pontos = 50;
        CantorResposta = Cantor[PersistentManagerScript.Instance.actualLevel];
        MusicaResposta = Musica[PersistentManagerScript.Instance.actualLevel];

        Debug.Log(CantorResposta + "" + MusicaResposta);
    }

    public void RepeatDica()
    {
        if (FirstDica.gameObject.activeSelf == false)
        {
            Debug.Log("Repetiu o som");
            playSound.selectPlaySound(Rounds);
        }      
    }

    public void IniciarJogo()
    {
        playSound.selectPlaySound(1);
        FirstDica.gameObject.SetActive(false);
        NextDica.gameObject.SetActive(true);
    }

    public void ProximaDica()
    {
        Debug.Log("Proxima dica");
        Rounds++;
        Pontos -= 10;
        playSound.selectPlaySound(Rounds);

        if (Rounds == 4)
        {
            NextDica.gameObject.SetActive(false);
            LastDica.gameObject.SetActive(true);

            LastDica.enabled = false;
            LastDica.image.color = new Color32(255, 255, 255, 120);
        }
    }

    public void UltimaDica()
    {
        Debug.Log("Ultima dica");
        Rounds++;
        Pontos -= 10;
        
        //Play AD
    }

    public void ConfirmarResposta()
    {
        if (inputResposta.text.ToUpper() == CantorResposta || inputResposta.text.ToUpper() == MusicaResposta)
        {
            changeScenes.NextScene(Pontos);
            Debug.Log("Certa Resposta");
        }
        else
        {
            inputResposta.text = "";
            Debug.Log("Resposta Errada");
            RepeatDica();
            if (Pontos != 10)
            {
                Pontos--;
            }          
        }
    }
}
