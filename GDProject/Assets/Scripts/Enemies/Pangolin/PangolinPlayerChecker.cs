using UnityEngine;

public class PangolinPlayerChecker : MonoBehaviour
{
    public PangolinAttack tongueAttack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tongueAttack.TryAttack();
        }
    }
}
