using System.Collections.Generic;
using UnityEngine;

public class HummingbirdBeakDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(transform.parent.parent.GetComponent<HummingbirdAttack>().damage);
            }
        }
    }
}
