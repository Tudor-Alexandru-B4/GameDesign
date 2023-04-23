using UnityEngine;

public class PangolinMovement : EnemyMovement
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            int direction = facingRight ? 1 : -1;
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -speed * Time.deltaTime);
        }
    }
}
