using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    public float health;
    public float armor;
    public float invincibilityTime;
    bool isInvincible = false;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0.0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            health -= damage / (1 + armor / 100);
            StartCoroutine(DamageUtils.ChangeColorOnGamage(gameObject));
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSecondsRealtime(invincibilityTime);
        isInvincible = false;
    }
}
