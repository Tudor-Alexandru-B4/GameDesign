using UnityEngine;

public class BossMovement : EnemyMovement
{
    public float speed;
    public PangolinAttack basicAttack;

    Vector2 direction = new Vector2(1, -1);
    bool stunned = false;
    bool changeX = true;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartMovement();
    }

    private void Update()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            basicAttack.canAttack = false;
            stunned = true;
        }else if (stunned)
        {
            StartMovement();
            basicAttack.canAttack = true;
            stunned = false;
        }
    }

    private void StartMovement()
    {
        rb.AddForce(direction.normalized * speed);
        RotateDirection();
    }

    private void RotateDirection()
    {
        if (changeX)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
        else
        {
            direction = new Vector2(direction.x, -direction.y);
        }
        changeX = !changeX;
    }

}
