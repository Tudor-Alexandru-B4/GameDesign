using UnityEngine;

public class DeathBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Player")
        {
            collision.GetComponent<HealthSystemPlayer>().health = -1;
        }
    }
}
