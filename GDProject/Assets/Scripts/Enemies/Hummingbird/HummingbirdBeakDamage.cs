using System.Collections.Generic;
using UnityEngine;

public class HummingbirdBeakDamage : MonoBehaviour
{
    float damage;

    private void Start()
    {
        damage = gameObject.GetComponentInParent<HummingbirdBeak>().damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
            }
        }
    }
}
