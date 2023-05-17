using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour
{
    public float damage;
    public float warningTime;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }
    
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(warningTime);
        
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;


        if (player)
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, player);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
            }
        }
        StartCoroutine(CleanExplosion());
    }

    IEnumerator CleanExplosion()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = null;
        }
    }
}
