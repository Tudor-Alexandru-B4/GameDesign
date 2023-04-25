using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerChip : AbilityMovement
{
    public float travelTime;
    public float travelSpeed;
    public float damage;
    public BasicAbilityDamage enemyChecker;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemyChecker.damage = damage;
        StartCoroutine(PockerChipLifeSpan());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = facingRight ? 1 : -1;
        rb.AddForce(direction * Vector2.right * travelSpeed);
    }

    IEnumerator PockerChipLifeSpan()
    {
        yield return new WaitForSeconds(travelTime);
        Destroy(gameObject);
    }
}
