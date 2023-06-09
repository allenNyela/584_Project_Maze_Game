using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    /* Walk Variables */
    [SerializeField] // this means that we can edit this value in the unity editor
    private float walkSpeed;

    /* Unity Varialbes */
    private Rigidbody2D body;

    [SerializeField]
    private Sprite left;
    [SerializeField]
    private Sprite right;
    [SerializeField]
    private Sprite up;
    [SerializeField]
    private Sprite down;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    public void Walk(Vector2 direction)
    {
        body.velocity = new Vector2(direction.x * walkSpeed, direction.y * walkSpeed);
    }

    private void FixedUpdate()
    {
        if (body.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }

        if (body.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }

        if (body.velocity.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = up;
        }

        if (body.velocity.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = down;
        }

    }
}