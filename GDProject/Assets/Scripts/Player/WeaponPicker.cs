using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    WeaponSpawner weaponSpawner = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WeaponSpawner")
        {
            weaponSpawner = collision.gameObject.GetComponent<WeaponSpawner>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WeaponSpawner")
        {
            weaponSpawner = null;
        }
    }

    public void TryToPickUp(AimGunScript anchor)
    {
        if(weaponSpawner != null)
        {
            if(weaponSpawner.transform.childCount <= 0)
            {
                return;
            }

            GameObject weapon = weaponSpawner.spawnedWeapon;

            weaponSpawner.bobbing = false;
            weaponSpawner.transform.GetChild(0).transform.rotation = Quaternion.identity;
            weaponSpawner.transform.GetChild(0).transform.localRotation = Quaternion.identity;

            GameObject oldGun = anchor.transform.GetChild(0).gameObject;
            GameObject newGun = Instantiate(weapon, anchor.transform);
            anchor.gun = newGun;
            Destroy(weaponSpawner.transform.GetChild(0).gameObject);
            weaponSpawner.SpawnWeapon(oldGun);

            if (Mathf.Abs(TransformUtils.WrapAngle(newGun.transform.rotation.eulerAngles.z)) > 90)
            {
                newGun.transform.Rotate(180, 0, 0);
            }

        }
    }
}
