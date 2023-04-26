using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                    movementSystem.canMove = false;
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
                    attackSystem.canAttack = false;
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
                    movementSystem.canMove = true;
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
                    attackSystem.canAttack = true;
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
            movement.canMove = false;
        }
        foreach (EnemyAttack attack in enemyAttackList)
        {
            attack.canAttack = false;
        }
        StartCoroutine(Detach(duration));
    }

    IEnumerator Detach(float duration)
    {
        yield return new WaitForSeconds(duration);
        stoppingTime = false;
        foreach (EnemyMovement movement in enemyMovementList)
        {
            movement.canMove = true;
        }
        foreach (EnemyAttack attack in enemyAttackList)
        {
            attack.canAttack = true;
        }
        gameObject.transform.parent = player.transform;
        gameObject.GetComponent<SpriteRenderer>().color = normal;
        gameObject.transform.localPosition = Vector3.zero;
    }

}
