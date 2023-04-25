using System.Collections.Generic;
using UnityEngine;

public class DamageCardBullet : BaseCardBullet
{
    public float extraDamage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage + extraDamage);
            }
            Destroy(gameObject);
        }
    }
}
