using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    GameObject weapon = null;
    WeaponSpawner weaponSpawner = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WeaponSpawner")
        {
            weaponSpawner = collision.gameObject.GetComponent<WeaponSpawner>();
            if (weaponSpawner.spawnedWeapon != null)
            {
                weapon = weaponSpawner.spawnedWeapon;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WeaponSpawner")
        {
            weapon = null;
            weaponSpawner = null;
        }
    }

    public void TryToPickUp(AimGunScript anchor)
    {
        if(weapon != null)
        {
            GameObject oldGun = anchor.transform.GetChild(0).gameObject;
            GameObject newGun = Instantiate(weapon, anchor.transform);
            anchor.gun = newGun;
            Destroy(oldGun.gameObject);
            Destroy(weaponSpawner.transform.GetChild(0).gameObject);
        }
    }
}
