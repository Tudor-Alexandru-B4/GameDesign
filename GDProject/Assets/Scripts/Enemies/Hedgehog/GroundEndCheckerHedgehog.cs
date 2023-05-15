using UnityEngine;

public class GroundEndCheckerHedgehog : MonoBehaviour
{
    public HedgehogMovement movement;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (!movement.isJumping)
            {
                movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                movement.Flip();
            }
        }
    }
}
