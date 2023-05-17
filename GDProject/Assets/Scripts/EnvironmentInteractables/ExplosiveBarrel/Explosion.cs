using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    List<IHealthSystem> healthSystems = new List<IHealthSystem>();
    List<GameObject> barrels = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("ExplosiveBarrel"))
        {
            return;
        }

        List<IHealthSystem> healthList;
        DamageUtils.GetInterfaces<IHealthSystem>(out healthList, collision.gameObject);
        foreach (IHealthSystem health in healthList)
        {
            if (!healthSystems.Contains(health))
            {
                healthSystems.Add(health);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.StartsWith("ExplosiveBarrel"))
        {
            return;
        }

        List<IHealthSystem> healthList;
        DamageUtils.GetInterfaces<IHealthSystem>(out healthList, collision.gameObject);
        foreach (IHealthSystem health in healthList)
        {
            if (healthSystems.Contains(health))
            {
                healthSystems.Remove(health);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.StartsWith("ExplosiveBarrel"))
        {
            if (!barrels.Contains(collision.gameObject))
            {
                barrels.Add(collision.gameObject);
            }
        }
    }

    public void Explode(float damage)
    {
        foreach(IHealthSystem health in healthSystems)
        {
            health.TakeDamage(damage);
        }

        foreach(GameObject barrel in barrels)
        {
            if (barrel)
            {
                barrel.GetComponent<BarrelHealthSystem>().Explode();
            }
        }

        Destroy(gameObject.transform.parent.gameObject);
    }
}
