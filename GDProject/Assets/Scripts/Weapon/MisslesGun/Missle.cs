using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float damage;
    public float speed;
    public float waitTime;

    float currentWait;

    LayerMask mask;
    List<GameObject> enemies = new List<GameObject>();
    GameObject currentTarget = null;

    void Start()
    {
        currentWait = waitTime;
        var layermask1 = 1 << 17;  // Ground
        mask = layermask1;
    }

    void Update()
    {
        if(currentWait <= 0)
        {
            Destroy(gameObject);
        }
        currentWait -= Time.deltaTime;
        TryToAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            if (!enemies.Contains(collision.gameObject))
            {
                enemies.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (enemies.Contains(collision.gameObject))
            {
                enemies.Remove(collision.gameObject);
            }
        }
    }

    private GameObject ComputeClosestTarget()
    {
        List<GameObject> potentialTargets = new List<GameObject>(enemies);
        GameObject target = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject potentialTarget in potentialTargets)
        {
            if (!potentialTarget)
            {
                if (enemies.Contains(potentialTarget))
                {
                    enemies.Remove(potentialTarget);
                }
                continue;
            }

            float distance = Vector3.Distance(transform.position, potentialTarget.transform.position);
            if (distance < minDistance && HasClearSight(potentialTarget))
            {
                minDistance = distance;
                target = potentialTarget;
            }
        }

        return target;
    }

    private bool HasClearSight(GameObject target)
    {
        if (Physics2D.Linecast(transform.position, target.transform.position, mask))
        {
            return false;
        }

        return true;
    }

    private void TryToAttack()
    {
        //Checks for enemies in range
        if (enemies.Count <= 0)
        {
            return;
        }

        //Gets closest enemy
        if (currentTarget == null)
        {
            currentTarget = ComputeClosestTarget();
        }

        //Validates current target existance
        if (!currentTarget)
        {
            if (enemies.Contains(currentTarget))
            {
                enemies.Remove(currentTarget);
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            currentTarget = null;
            return;
        }
        else if (!HasClearSight(currentTarget))
        {
            currentTarget = null;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        var enemyPosition = currentTarget.transform.position;

        currentWait = waitTime;

        //rotate bullet
        Vector2 directionForBullet;
        directionForBullet = enemyPosition - transform.position;
        directionForBullet.Normalize();
        float rot_z = Mathf.Atan2(directionForBullet.y, directionForBullet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        var direction = transform.position - enemyPosition;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * -speed * Time.deltaTime;
    }
}
