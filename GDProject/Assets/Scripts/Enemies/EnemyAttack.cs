using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool canAttack = true;

    float attackingCooldown = 0f;
    bool wasStunnedAlready = false;

    public virtual void StopCorutines() { }

    public void Update()
    {
        if(attackingCooldown > 0f)
        {
            attackingCooldown -= Time.deltaTime;
            wasStunnedAlready=true;
        }
        else
        {
            if (wasStunnedAlready)
            {
                canAttack = true;
                wasStunnedAlready =false;
            }
        }
    }

    public void Stun(float stunTime)
    {
        if(stunTime > attackingCooldown)
        {
            attackingCooldown = stunTime;
            canAttack = false;
        }
    }
}
