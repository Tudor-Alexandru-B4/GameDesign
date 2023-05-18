using System;
using UnityEngine;

public class HummingbirdMovement : EnemyMovement
{
    public Transform backdoor;
    public float rotationSpeed = 15f;
    GameObject player = null;
    Rigidbody2D rb;

    bool wasStunned = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        if(canMove)
        {
            if(wasStunned)
            {
                transform.position = backdoor.position;
                wasStunned = false;
            }
            rb.constraints = RigidbodyConstraints2D.None;

            Vector3 diff = player.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            float z = Math.Abs(TransformUtils.WrapAngle(rot_z));

            if(z > 90)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(180f, 0f, -(rot_z - 180));
            }

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            wasStunned = true;
        }
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }
}
