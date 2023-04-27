using System.Collections;
using UnityEngine;

public class HummingbirdAttack : EnemyAttack
{
    public float attackSpeed;
    public float damage;
    public float stuckTime;
    public float hazeTime = 1;
    Rigidbody2D rb;
    HummingbirdMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = gameObject.GetComponent<HummingbirdMovement>();
        StartCoroutine(SpawnHaze());
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            movement.canMove = false;
            canAttack = false;
            rb.AddForce(-transform.right * attackSpeed);
        }
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }
    
    public IEnumerator SpawnHaze()
    {
        yield return new WaitForSeconds(hazeTime);
        canAttack = true;
    }
}
