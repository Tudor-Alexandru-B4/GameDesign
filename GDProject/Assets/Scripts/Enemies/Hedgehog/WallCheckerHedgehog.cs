using UnityEngine;

public class WallCheckerHedgehog : MonoBehaviour
{
    public HedgehogMovement movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Stopper" || collision.tag == "Platform")
        {
            if (!movement.isJumping)
            {
                movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                movement.Flip();
            }
        }
    }
}
