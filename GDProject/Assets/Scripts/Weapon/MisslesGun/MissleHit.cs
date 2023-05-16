using System.Collections.Generic;
using UnityEngine;

public class MissleHit : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(transform.parent.GetComponent<Missle>().damage);
            }
            Destroy(transform.parent.gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
