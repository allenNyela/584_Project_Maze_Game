using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
    private bool hasKey;
    [SerializeField]
    private GameObject key_1;
    [SerializeField]
    private GameObject key_2;
    [SerializeField]
    private GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key" || collision.gameObject.tag == "Key_2")
        {
            hasKey = true;
            if (collision.gameObject.tag == "Key") {
                key_1.SetActive(false);
            }
            if (collision.gameObject.tag == "Key_2") {
                key_2.SetActive(false);
            }

            exit.SetActive(true);
            
        }

        if (collision.gameObject.tag == "Exit")
        {
            if (hasKey == true) {
                SceneManager.LoadScene(2);
            }
        }
    }
}
