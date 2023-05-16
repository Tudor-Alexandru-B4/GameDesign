using System.Collections.Generic;
using UnityEngine;

public class EngineerTurret : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public float attackCooldown;
    public float damage;
    public float speed;

    public float spawnTime;

    float cooldown = 0f;

    LayerMask mask;
    List<GameObject> enemies = new List<GameObject>();
    GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        var layermask1 = 1 << 2;  // Player
        var layermask2 = 1 << 5;  // Bullet
        var layermask3 = 1 << 6;  // Enemy
        var layermask4 = 1 << 8;  // Checker
        var layermask5 = 1 << 9;  // EnemyAttack
        var layermask6 = 1 << 10; // Ability
        var layermask7 = 1 << 12; // SmallPlatform
        var layermask8 = 1 << 13; // Boundry
        var layermask9 = 1 << 15; // Turret
        mask = layermask1 | layermask2 | layermask3 | layermask4 | layermask5 | layermask6 | layermask7 | layermask8 | layermask9;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            Destroy(gameObject);
        }
        spawnTime -= Time.deltaTime;

        if(cooldown <= 0f)
        {
            TryToAttack();
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            if (!enemies.Contains(collision.gameObject))
            {
                enemies.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
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

        foreach(GameObject potentialTarget in potentialTargets)
        {
            if (!potentialTarget)
            {
                if (enemies.Contains(potentialTarget))
                {
                    enemies.Remove(potentialTarget);
                }
                continue;
            }

            float distance = Vector3.Distance(firePoint.transform.position, potentialTarget.transform.position);
            if(distance < minDistance && HasClearSight(potentialTarget))
            {
                minDistance = distance;
                target = potentialTarget;
            }
        }

        return target;
    }

    private bool HasClearSight(GameObject target)
    {
        if (Physics2D.Linecast(firePoint.transform.position, target.transform.position, mask))
        {
            return false;
        }

        return true;
    }

    private void TryToAttack()
    {
        //Checks for enemies in range
        if(enemies.Count <= 0)
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
            currentTarget = null;
            return;
        }
        var enemyPosition = currentTarget.transform.position;
        
        var bullet = Instantiate(bulletPrefab, firePoint.transform);
        firePoint.transform.DetachChildren();

        //rotate bullet
        Vector2 directionForBullet;
        directionForBullet = enemyPosition - bullet.transform.position;
        directionForBullet.Normalize();
        float rot_z = Mathf.Atan2(directionForBullet.y, directionForBullet.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        bullet.GetComponent<BasicBulletScript>().damage = damage;

        var direction = firePoint.transform.position - enemyPosition;
        bullet.GetComponent<Rigidbody2D>().AddForce(direction * -speed);

        cooldown = attackCooldown;
    }

}
