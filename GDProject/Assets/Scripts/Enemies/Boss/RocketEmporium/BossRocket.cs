using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRocket : MonoBehaviour
{
    public float damage;
    public float speed;
    public float warningTime;
    public float destroyX;
    public bool goesRight = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRocket());
    }

    // Update is called once per frame
    void Update()
    {
        if (goesRight)
        {
            if(transform.position.x > destroyX)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if(transform.position.x < destroyX)
            {
                Destroy(gameObject);
            }
        }
    }
    
    IEnumerator StartRocket()
    {
        yield return new WaitForSeconds(warningTime);
        if (goesRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
            }
        }
    }
}
