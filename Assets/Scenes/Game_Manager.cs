using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    // game timers
    [SerializeField]
    private float gameTimer = 180;

    [SerializeField]
    public GameObject theTimer;

    [SerializeField]
    private GameObject playerTime;

    void Awake()
    {
        gameTimer = Time.time + gameTimer;
      
    }


    // Update is called once per frame
    void Update()
    {
        int a = (int)System.Math.Round(gameTimer - Time.time);
        theTimer.GetComponent<TextMeshProUGUI>().text = a.ToString();
        PlayerPrefs.SetFloat("Player Time", Time.time);

        if (Time.time > gameTimer)
        {
            SceneManager.LoadScene(2);
        }

    }
}
