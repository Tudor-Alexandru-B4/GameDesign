using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public EnemyMovement movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" || collision.tag == "Stopper")
        {
            movement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            movement.Flip();
        }
    }
}
