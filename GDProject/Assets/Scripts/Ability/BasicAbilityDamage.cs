using System.Collections.Generic;
using UnityEngine;

public class BasicAbilityDamage : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT");
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
            }
        }
    }
}
