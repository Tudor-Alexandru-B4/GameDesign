using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public EnemyMovement movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            movement.Flip();
        }
    }
}
