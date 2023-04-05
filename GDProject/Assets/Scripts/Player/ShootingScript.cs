using System.Linq;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public AimGunScript gunAnchor;

    bool isPressed = false;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
       

        if (CheckShootingStart())
        {
            isPressed = true;
        }

        if (isPressed & canShoot)
        {
            StartCoroutine(gunAnchor.gun.GetComponent<WeaponScript>().Shoot());
        }

        if (CheckShootingEnd())
        {
            isPressed = false;
        }
    }

    bool CheckShootingStart()
    {
        if(Input.GetJoystickNames().Any(e => e.Length > 0))
        {
            if (Input.GetAxis("FireController") != 0)
            {
                return true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                return true;
            }
        }

        return false;
    }

    bool CheckShootingEnd()
    {
        if (Input.GetJoystickNames().Any(e => e.Length > 0))
        {
            if (Input.GetAxis("FireController") == 0)
            {
                return true;
            }
        }
        else
        {
            if (Input.GetButtonUp("Fire1"))
            {
                return true;
            }
        }

        return false;
    }
}
