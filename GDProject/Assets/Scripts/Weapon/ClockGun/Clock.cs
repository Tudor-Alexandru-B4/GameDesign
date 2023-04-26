using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float recallDistance;
    public float recallSpeed;
    public float increaseSize;
    public float damage;
    Vector3 startPosition;
    Rigidbody2D rb;
    GameObject player;
    bool isRecalling = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRecalling || Vector3.Distance(startPosition, transform.position) >= recallDistance)
        {
            if(!isRecalling)
            {
                rb.velocity = Vector3.zero;
                transform.localScale = Vector3.one * increaseSize;
                isRecalling = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, recallSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                healthSystem.TakeDamage(damage);
            }
        }else if (collision.gameObject.tag == "Player" && isRecalling)
        {
            Destroy(gameObject);
        }
    }
}
