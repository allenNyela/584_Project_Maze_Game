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
        timer = Time.time + 15.0f;

        float a = PlayerPrefs.GetFloat("Player Time");
        thePlayerTime.GetComponent<TextMeshProUGUI>().text = a.ToString();
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            SceneManager.LoadScene(0);
        }
    }
}
