using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public int dashDistance;
    public int maxDashCounter;
    public float dashTime;
    public float jumpSpeed;
    public int maxJumpCounter;

    [System.NonSerialized] public int jumpCounter;
    [System.NonSerialized] public int dashCounter;
    [System.NonSerialized] public bool facingRight;

    private float dashTimeCountdown;
    private bool isDashing;

    private Rigidbody2D body;
    [System.NonSerialized] public Transform trans;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        jumpCounter = maxJumpCounter;
        dashCounter = maxDashCounter;
        dashTimeCountdown = 0;
        facingRight = true;
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            flip();
        }
        if(Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            flip();
        }

        if (isDashing)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * dashSpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }

        if(dashCounter > 0 && dashTimeCountdown <= 0 && Input.GetButtonDown("Dash"))
        {
            body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            isDashing = true;
            dashTimeCountdown = dashTime;
            dashCounter--;
        }

        if(dashTimeCountdown > 0)
        {
            dashTimeCountdown -= Time.deltaTime;
        }
        else
        {
            if (isDashing)
            {
                body.velocity = Vector2.zero;
                body.constraints = RigidbodyConstraints2D.FreezeRotation;
                isDashing = false;
            }
        }

        if (jumpCounter > 0 && Input.GetButtonDown("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            jumpCounter--;
        }
    }

    public void SpeedEffect(float time, float newSpeed)
    {
        StartCoroutine(SpeedChangeTimed(time, newSpeed));
    }

    IEnumerator SpeedChangeTimed(float time, float newSpeed)
    {
        var basicSpeed = speed;
        speed += newSpeed;
        yield return new WaitForSeconds(time);
        speed = basicSpeed;
    }
    
    void flip()
    {
        facingRight = !facingRight;
        trans.Rotate(0, 180, 0);
    }

}