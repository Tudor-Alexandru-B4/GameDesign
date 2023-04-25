using System.Collections.Generic;
using UnityEngine;

public class HealCardBullet : BaseCardBullet
{
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
                GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().Heal(heal);
            }
            Destroy(gameObject);
        }
    }
}
