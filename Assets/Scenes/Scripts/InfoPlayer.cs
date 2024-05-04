using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPlayer : MonoBehaviour
{
    float volume;
    string resolucao;
    int score=0;

    [SerializeField] Text playerInfos;
    // Start is called before the first frame update
    void Start()
    {
        SavePrefs();
        //PlayerPrefs.DeleteAll();
    }

    public void SavePrefs(){
        PlayerPrefs.SetFloat("Vol", 10.0f);
        PlayerPrefs.SetString("Resolucao", "1280");
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadPrefs(){
        volume = PlayerPrefs.GetFloat("Vol");
        resolucao = PlayerPrefs.GetString("Resolucao");
        score = PlayerPrefs.GetInt("Score");

        playerInfos.text = "Volume: " + volume + "\n" +
                           "Resolução: " + resolucao + "\n" +
                           "Score: " + score + ".";

        
    }


}
