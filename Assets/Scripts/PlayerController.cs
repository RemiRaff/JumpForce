using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700; // force added for the jump
    public float gravityModifier = 1.5f; // for landing quickly after a jump
    public bool gameOver; // flag for game over used in other scripts
    public ParticleSystem explosionParticle;
    public ParticleSystem splatterParticle;

    private Rigidbody playerRB;
    private Animator playerAnim;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        // GetComponentInChildren because Animator in child (character gameobject)
        playerAnim = GetComponentInChildren<Animator>();

        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // transform.translate
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
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
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            splatterParticle.Stop();
        }
    }
}
