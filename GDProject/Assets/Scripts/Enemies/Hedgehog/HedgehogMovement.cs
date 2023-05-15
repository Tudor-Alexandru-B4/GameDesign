using UnityEngine;

public class HedgehogMovement : EnemyMovement
{
    public float speed;
    public float jumpChancePerFrame;
    public float jumpForce;
    public bool isJumping = false;
    public Rigidbody2D rb;

    HedgehogAttack attack;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        attack = gameObject.GetComponent<HedgehogAttack>();
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove && !isJumping)
        {

            if(Random.Range(1, 101) <= jumpChancePerFrame)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(transform.up * jumpForce);
                isJumping = true;
                attack.CheckForAttack(this);
            }
            else
            {
                rb.AddForce(transform.right * -speed);
            }
        }
    }
}
