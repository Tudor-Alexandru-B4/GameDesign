using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopRange : MonoBehaviour
{
    public Color normal;
    public Color active;
    List<EnemyMovement> enemyMovementList = new List<EnemyMovement>();
    List<EnemyAttack> enemyAttackList = new List<EnemyAttack>();
    GameObject player;
    bool stoppingTime = false;

    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            List<EnemyMovement> movementList;
            DamageUtils.GetInterfaces<EnemyMovement>(out movementList, collision.gameObject);
            foreach (EnemyMovement movementSystem in movementList)
            {
                if (!enemyMovementList.Contains(movementSystem))
                {
                    enemyMovementList.Add(movementSystem);
                }

                if(stoppingTime)
                {
                    StopMovement(movementSystem);
                }
            }

            List<EnemyAttack> attackList;
            DamageUtils.GetInterfaces<EnemyAttack>(out attackList, collision.gameObject);
            foreach (EnemyAttack attackSystem in attackList)
            {
                if (!enemyAttackList.Contains(attackSystem))
                {
                    enemyAttackList.Add(attackSystem);
                }

                if (stoppingTime)
                {
                    StopAttack(attackSystem);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            List<EnemyMovement> movementList;
            DamageUtils.GetInterfaces<EnemyMovement>(out movementList, collision.gameObject);
            foreach (EnemyMovement movementSystem in movementList)
            {
                if (enemyMovementList.Contains(movementSystem))
                {
                    enemyMovementList.Remove(movementSystem);
                }

                if (stoppingTime)
                {
                    StartMovement(movementSystem);
                }
            }

            List<EnemyAttack> attackList;
            DamageUtils.GetInterfaces<EnemyAttack>(out attackList, collision.gameObject);
            foreach (EnemyAttack attackSystem in attackList)
            {
                if (enemyAttackList.Contains(attackSystem))
                {
                    enemyAttackList.Remove(attackSystem);
                }

                if (stoppingTime)
                {
                    StartAttack(attackSystem);
                }
            }
        }
    }

    public void TimeStop(float duration)
    {
        stoppingTime = true;
        gameObject.GetComponent<SpriteRenderer>().color = active;
        gameObject.transform.parent = player.transform.parent;
        foreach (EnemyMovement movement in enemyMovementList)
        {
            StopMovement(movement);
        }

        foreach (EnemyAttack attack in enemyAttackList)
        {
            StopAttack(attack);
        }
        
        StartCoroutine(Detach(duration));
    }

    IEnumerator Detach(float duration)
    {
        yield return new WaitForSeconds(duration);
        stoppingTime = false;
        foreach (EnemyMovement movement in enemyMovementList)
        {
            StartMovement(movement);
        }
        foreach (EnemyAttack attack in enemyAttackList)
        {
            StartAttack(attack);
        }
        gameObject.transform.parent = player.transform;
        gameObject.GetComponent<SpriteRenderer>().color = normal;
        gameObject.transform.localPosition = Vector3.zero;
    }

    void StopMovement(EnemyMovement movement)
    {
        movement.StopCorutines();
        var movementRb = movement.gameObject.GetComponent<Rigidbody2D>();
        if (movementRb != null)
        {
            movementRb.velocity = Vector3.zero;
        }
        movement.canMove = false;
    }

    void StopAttack(EnemyAttack attack)
    {
        attack.StopCorutines();
        attack.canAttack = false;
    }

    void StartMovement(EnemyMovement movement)
    {
        movement.canMove = true;
    }

    void StartAttack(EnemyAttack attack)
    {
        attack.canAttack = true;
    }

}
