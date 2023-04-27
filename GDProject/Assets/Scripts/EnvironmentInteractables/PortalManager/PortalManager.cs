using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Color color;
    public Portal portal1;
    public Portal portal2;
    public float waitOnPortal;
    bool canTeleport = true;

    // Start is called before the first frame update
    void Start()
    {
        SetPortalsColor();
    }

    [Button]
    public void SetPortalsColor()
    {
        portal1.GetComponent<SpriteRenderer>().color = color;
        portal2.GetComponent<SpriteRenderer>().color = color;
    }

    public void Teleport(int number, GameObject obj)
    {
        if(canTeleport)
        {
            if (number == 1)
            {
                obj.transform.position = portal1.teleportPoint.position;
            }
            else
            {
                obj.transform.position = portal2.teleportPoint.position;
            }
            StartCoroutine(WaitOnPortal());
        }
    }

    IEnumerator WaitOnPortal()
    {
        canTeleport = false;
        yield return new WaitForSeconds(waitOnPortal);
        canTeleport = true;
    }
}
