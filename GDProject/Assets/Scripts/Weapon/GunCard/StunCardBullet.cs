using System.Collections.Generic;
using UnityEngine;

public class StunCardBullet : BaseCardBullet
{
    public float stunTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);

                List<EnemyMovement> movementList;
                DamageUtils.GetInterfaces<EnemyMovement>(out movementList, collision.gameObject);
                foreach (EnemyMovement movementSystem in movementList)
                {
                    movementSystem.Stun(stunTime);
                }

                List<EnemyAttack> attackList;
                DamageUtils.GetInterfaces<EnemyAttack>(out attackList, collision.gameObject);
                foreach (EnemyAttack attackSystem in attackList)
                {
                    attackSystem.Stun(stunTime);
                }
            }
            Destroy(gameObject);
        }
    }
}
