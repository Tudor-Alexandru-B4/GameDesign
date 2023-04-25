using UnityEngine;

public class AbilityWallChecker : MonoBehaviour
{
    public AbilityMovement movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            movement.Flip();
        }
    }
}
