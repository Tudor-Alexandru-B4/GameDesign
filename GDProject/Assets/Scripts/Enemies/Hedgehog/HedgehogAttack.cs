using System.Collections;
using UnityEngine;

public class HedgehogAttack : EnemyAttack
{
    public GameObject spinesPrefab;
    public float cooldown;
    public float damage;

    bool checking = false;
    HedgehogMovement movement;

    public void TryAttack()
    {
        if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    override
    public void StopCorutines()
    {
        StopAllCoroutines();
    }

    void FixedUpdate()
    {
        if(checking)
        {
            if(movement.rb.velocity.y <= 0)
            {
                checking = false;
                StartCoroutine(Attack());
            }
        }
    }

    public void CheckForAttack(HedgehogMovement hMovement)
    {
        checking = true;
        movement = hMovement;
    }

    IEnumerator Attack()
    {
        canAttack = false;
        var spines = Instantiate(spinesPrefab);
        spines.transform.parent = gameObject.transform;
        spines.transform.localPosition = new Vector3(0f, -0.04f, 0f);
        foreach(Transform child in spines.transform)
        {
            child.gameObject.GetComponent<SpikeMovement>().damage = damage;
        }
        spines.transform.DetachChildren();
        Destroy(spines);
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
