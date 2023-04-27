using UnityEngine;

public class Portal : MonoBehaviour
{
    public int number;
    public Transform teleportPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy" || collision.tag == "Bullet")
        {
            gameObject.GetComponentInParent<PortalManager>().Teleport(number, collision.gameObject);
        }
    }
}
