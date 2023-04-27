using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject leftBoundry;
    public GameObject rightBoundry;
    public float speed;
    public bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightBoundry.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, leftBoundry.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform.parent.parent;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightBoundry")
        {
            moveRight = false;
        }

        if (collision.gameObject.tag == "LeftBoundry")
        {
            moveRight = true;
        }
    }
}
