using UnityEngine;

public class BarrelHealthSystem : MonoBehaviour, IHealthSystem
{
    float maxHealth;
    public float damage;
    public float health;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        maxHealth = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        spriteRenderer.color = new Color(1.5f - health/maxHealth, 0, 0, 1);
        health--;
    }

    public void Explode()
    {
        spriteRenderer.color = new Color(1.5f - health / maxHealth, 0, 0, 1);
        spriteRenderer.color = new Color(1.5f - health / maxHealth, 0, 0, 1);
        spriteRenderer.color = new Color(1.5f - health / maxHealth, 0, 0, 1);
        health = 0;
    }

    private void Update()
    {
        if (health <= 0)
        {
            spriteRenderer.sprite = null;
            gameObject.transform.GetChild(0).GetComponent<Explosion>().Explode(damage);
        }
    }
}
