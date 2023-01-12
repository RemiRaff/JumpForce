using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier = 3;
    public bool gameOver;

    private Rigidbody playerRB;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // transform.translate
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!...");
        }
    }
}
