using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public WeaponScript gun;

    bool isPressed = false;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetAxis("FireController") != 0)
        {
            isPressed = true;
        }

        if (isPressed & canShoot)
        {
            StartCoroutine(gun.Shoot());
        }

        if (Input.GetButtonUp("Fire1") || Input.GetAxis("FireController") == 0)
        {
            isPressed = false;
        }
    }
}
