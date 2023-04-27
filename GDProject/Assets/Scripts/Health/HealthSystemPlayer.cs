using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystemPlayer : MonoBehaviour, IHealthSystem
{
    public float maxHealth;
    public float health;
    public float armor;
    public float invincibilityTime;
    bool isInvincible = false;

    private void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0)
        {
            Destroy(GameObject.Find("PlayerManager"));
            SceneManager.LoadScene("StartScene");
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

    public void Heal(float heal)
    {
        if (health + heal < maxHealth)
        {
            health += heal;
        }
        else
        {
            health = maxHealth;
        }
    }

    public void HealthEffect(float time, float newHealth)
    {
        StartCoroutine(HealthChangeTimed(time, newHealth));
    }

    IEnumerator HealthChangeTimed(float time, float newHealth)
    {
        if (health + newHealth < 1)
        {
            health = 1;
        }
        else
        {
            health += newHealth;
        }

        yield return new WaitForSeconds(time);
        newHealth = -newHealth;

        if (health + newHealth < 1)
        {
            health = 1;
        }
        else
        {
            health += newHealth;
        }
    }

    public void ArmorEffect(float time, float newArmor)
    {
        StartCoroutine(ArmorChangeTimed(time, newArmor));
    }

    IEnumerator ArmorChangeTimed(float time, float newArmor)
    {
        if (armor + newArmor < 1)
        {
            armor = 1;
        }
        else
        {
            armor += newArmor;
        }

        yield return new WaitForSeconds(time);
        newArmor = -newArmor;

        if (armor + newArmor < 1)
        {
            armor = 1;
        }
        else
        {
            armor += newArmor;
        }
    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSecondsRealtime(invincibilityTime);
        isInvincible = false;
    }
}
