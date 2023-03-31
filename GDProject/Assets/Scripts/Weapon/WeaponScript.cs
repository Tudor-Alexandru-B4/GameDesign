using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public virtual IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(0f);
    }
}
