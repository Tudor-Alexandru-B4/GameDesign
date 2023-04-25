using UnityEngine;

public class AbilityMovement : MonoBehaviour
{
    public bool facingRight = true;

    public void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0, 180, 0);
    }
}
