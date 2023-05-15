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
            if (weaponSpawner.transform.childCount > 0)
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
            weaponSpawner.bobbing = false;
            weaponSpawner.transform.GetChild(0).transform.rotation = Quaternion.identity;
            weaponSpawner.transform.GetChild(0).transform.localRotation = Quaternion.identity;

            GameObject oldGun = anchor.transform.GetChild(0).gameObject;
            GameObject newGun = Instantiate(weapon, anchor.transform);
            anchor.gun = newGun;
            Destroy(oldGun.gameObject);
            Destroy(weaponSpawner.transform.GetChild(0).gameObject);

            if(Mathf.Abs(TransformUtils.WrapAngle(newGun.transform.rotation.eulerAngles.z)) > 90)
            {
                newGun.transform.Rotate(180, 0, 0);
            }

        }
    }
}
