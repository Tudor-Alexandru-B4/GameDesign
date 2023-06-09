using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{

    PlayerMovementScript playerMovement;

    private void Awake()
    {
        playerMovement = transform.parent.GetComponent<PlayerMovementScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            Restore();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            Restore();
        }
    }

    private void Restore()
    {
        playerMovement.jumpCounter = playerMovement.maxJumpCounter;
        playerMovement.dashCounter = playerMovement.maxDashCounter;
    }

}
