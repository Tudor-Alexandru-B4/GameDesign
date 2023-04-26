using System.Collections;
using UnityEngine;

public class HummingbirdBeak : MonoBehaviour
{
    public float damage;
    float stuckTime;
    HummingbirdAttack attack;
    HummingbirdMovement movement;
    GameObject hummingbird;


    // Start is called before the first frame update
    void Start()
    {
        hummingbird = gameObject.transform.parent.gameObject;
        attack = hummingbird.GetComponent<HummingbirdAttack>();
        movement = hummingbird.GetComponent<HummingbirdMovement>();
        damage = attack.damage;
        stuckTime = attack.stuckTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            hummingbird.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            StartCoroutine(Stuck());
        }
    }

    IEnumerator Stuck()
    {
        yield return new WaitForSeconds(stuckTime);
        movement.canMove = true;
        StartCoroutine(attack.SpawnHaze());
    }
}
