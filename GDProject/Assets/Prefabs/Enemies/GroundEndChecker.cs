using UnityEngine;

public class GroundEndChecker : MonoBehaviour
{
    public EnemyMovement movement;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            movement.Flip();
        }
    }
}
