using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float armor;
    public float invincibilityTime;
    public bool isPlayer = false;
    bool isInvincible = false;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0.0)
        {
            if (isPlayer)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            health -= damage / (1 + armor / 100);
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
