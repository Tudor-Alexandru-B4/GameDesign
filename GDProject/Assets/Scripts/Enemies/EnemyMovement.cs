using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool facingRight = true;
    public bool canMove = true;

    float movingCooldown = 0f;
    bool wasStunnedAlready = false;

    public void Flip()
    {
        facingRight = !facingRight;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.transform.Rotate(0, 180, 0);
    }

    public virtual void StopCorutines() { }

    public void Update()
    {
        if (movingCooldown >= 0)
        {
            movingCooldown -= Time.deltaTime;
            wasStunnedAlready = true;
        }
        else
        {
            if (wasStunnedAlready)
            {
                canMove = true;
                wasStunnedAlready = false;
            }
        }
    }

    public void Stun(float stunTime)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (stunTime > movingCooldown)
        {
            movingCooldown = stunTime;
            canMove = false;
        }
    }
}
