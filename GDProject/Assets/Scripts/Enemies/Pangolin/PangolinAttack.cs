using System.Collections;
using UnityEngine;

public class PangolinAttack : EnemyAttack
{
    public GameObject tonguePrefab;
    public float cooldown;
    public float damage;

    Coroutine attack = null;

    public void TryAttack()
    {
        if (canAttack)
        {
            attack = StartCoroutine(Attack());
        }
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }

    IEnumerator Attack()
    {
        canAttack = false;
        var toungue = Instantiate(tonguePrefab);
        toungue.transform.GetChild(0).GetComponent<ToungueDamagePlayer>().damage = damage;
        toungue.transform.parent = gameObject.transform;
        toungue.transform.localPosition = new Vector3(0f, -0.04f, 0f);
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
