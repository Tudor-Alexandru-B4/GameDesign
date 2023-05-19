using System.Collections;
using UnityEngine;

public class ExplosiveBullet : BasicBulletScript
{
    public GameObject explosionPrefab;
    public float explosionVisibleTime = 0.1f;
    GameObject explosion;
    SpriteRenderer explosionRenderer;

    private void Start()
    {
        explosion = Instantiate(explosionPrefab, gameObject.transform);
        transform.DetachChildren();
        explosion.GetComponent<FollowingScript>().toFollow = gameObject;
        explosion.GetComponent<Explosion>().specialParent = gameObject;
        explosion.transform.localPosition = Vector3.zero;
        explosionRenderer = explosion.GetComponent<SpriteRenderer>();
        explosionRenderer.enabled = false;
    }

    override
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            PrepareExplosion();
        }
    }

    override
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PrepareExplosion();
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionVisibleTime);
        explosion.GetComponent<Explosion>().Explode(damage);
    }

    private void PrepareExplosion()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        explosionRenderer.enabled = true;
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.velocity = Vector3.zero;
        StartCoroutine(Explode());
    }
}
