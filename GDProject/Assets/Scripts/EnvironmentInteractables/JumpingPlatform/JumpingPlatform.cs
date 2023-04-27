using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    public float jumpForce;
    public float jumpForceFromBelow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y - collision.transform.position.y < 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForceFromBelow);
            }
        }
    }

}
