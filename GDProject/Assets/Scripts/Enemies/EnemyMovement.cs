using System.Collections;
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

    public void Stun(float stunTime)
    {
        Debug.Log("STUN");
        if (canMove)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(Stunned(stunTime));
        }
    }

    IEnumerator Stunned(float stunnTime)
    {
        canMove = false;
        Debug.Log(canMove);
        yield return new WaitForSeconds(stunnTime);
        canMove = true;
    }
}
