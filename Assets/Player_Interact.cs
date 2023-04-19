using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
    private int hasKey;
    [SerializeField]
    private GameObject key_1;
    [SerializeField]
    private GameObject key_2;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject enemy_2;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = 0;
        exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            hasKey++;
            if (collision.gameObject.tag == "Key") {
                key_1.SetActive(false);
            }
            
        }

        if (collision.gameObject.tag == "Key_2")
        {
            hasKey++;
            if (collision.gameObject.tag == "Key_2") {
                key_2.SetActive(false);
            }
            
        }

        if (hasKey == 2) {
            exit.SetActive(true);
        }

        if (collision.gameObject.tag == "Exit")
        {
            if (hasKey == 2) {
                SceneManager.LoadScene(2);
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(3);
        }
    }
}
