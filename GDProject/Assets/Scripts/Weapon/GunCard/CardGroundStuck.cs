using System.Collections;
using UnityEngine;

public class CardGroundStuck : MonoBehaviour
{

    public float groundStuckTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            gameObject.layer = LayerMask.NameToLayer("Null");
            StartCoroutine(DespawnTime());
        }
    }

    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(groundStuckTime);
        Destroy(gameObject);
    }

}
