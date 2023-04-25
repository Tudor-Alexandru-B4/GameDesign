using UnityEngine;

public class PangolinMovement : EnemyMovement
{
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddForce(transform.right * -speed);
        }
    }
}
