using System.Collections;
using UnityEngine;

public class PangolinAttack : MonoBehaviour
{
    public GameObject tonguePrefab;
    public float cooldown;
    public float damage;
    bool canAttack = true;

    public void TryAttack()
    {
        if (canAttack)
        {
            StartCoroutine(Attack());
        }
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
