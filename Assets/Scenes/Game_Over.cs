using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    private float timer;
 
    void Start()
    {
        timer = Time.time + 5.0f;
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            SceneManager.LoadScene(0);
        }
    }
}
