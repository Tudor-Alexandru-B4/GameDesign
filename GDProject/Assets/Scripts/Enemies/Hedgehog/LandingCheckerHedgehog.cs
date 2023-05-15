using UnityEngine;

public class LandingCheckerHedgehog : MonoBehaviour
{
    public HedgehogMovement movement;
    public float fallinghTreshold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Platform")
        {
            if(movement.rb.velocity.y <= fallinghTreshold)
            {
                movement.isJumping = false;
            }
        }
    }
}
