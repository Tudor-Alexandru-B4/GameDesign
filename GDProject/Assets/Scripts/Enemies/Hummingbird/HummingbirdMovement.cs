using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HummingbirdMovement : EnemyMovement
{
    public float rotationSpeed = 15f;
    GameObject player = null;
    Rigidbody2D rb;

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
        }
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }
}
