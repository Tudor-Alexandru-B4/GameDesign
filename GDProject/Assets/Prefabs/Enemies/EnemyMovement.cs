using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool facingRight = true;
    public bool canMove = true;

    public void Flip()
    {
        facingRight = !facingRight;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.transform.Rotate(0, 180, 0);
    }
}
