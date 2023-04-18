using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_Screen : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private GameObject thePlayerTime;
 
    void Start()
    {
        timer = Time.time + 8.0f;

        float playerTimeFloat = PlayerPrefs.GetFloat("Player Time");
        int playerTimeInt = (int)System.Math.Round(playerTimeFloat);
        thePlayerTime.GetComponent<TextMeshProUGUI>().text = playerTimeInt.ToString();
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            SceneManager.LoadScene(0);
        }
    }
}
