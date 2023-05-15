using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float damage;
    public float speed;
    public int goingFront;
    public int goingUp;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-speed * goingFront, speed * goingUp, 0f));
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
                Destroy(gameObject);
            }
        }
        
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
