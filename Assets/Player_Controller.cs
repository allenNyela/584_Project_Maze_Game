using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
   
    /* Other Scripts */
    private Player_Movement playerMovement;
    private Player_Animator playerAnimator;

    void Start()
    {
        playerMovement = GetComponent<Player_Movement>();
        playerAnimator = GetComponent<Player_Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        /* Directional Input */
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        /* Walking */
        playerMovement.Walk(moveDirection);

        /* Play the necessary animation */
        if (moveX == 0 && moveY == 0)
        {
            playerAnimator.IdleAnimation();
        }
        else
        {
            playerAnimator.WalkAnimation();
        }

    }
}

