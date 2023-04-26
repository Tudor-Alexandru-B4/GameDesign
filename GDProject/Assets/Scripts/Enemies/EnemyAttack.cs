using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool canAttack = true;

    public void Stun(float stunTime)
    {
        StartCoroutine(Stunned(stunTime));
    }

    IEnumerator Stunned(float stunnTime)
    {
        canAttack = false;
        yield return new WaitForSeconds(stunnTime);
        canAttack = true;
    }
}
