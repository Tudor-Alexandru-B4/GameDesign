using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    List<IHealthSystem> healthSystems = new List<IHealthSystem>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    public void Explode(float damage)
    {
        foreach(IHealthSystem health in healthSystems)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject.transform.parent.gameObject);
    }
}
