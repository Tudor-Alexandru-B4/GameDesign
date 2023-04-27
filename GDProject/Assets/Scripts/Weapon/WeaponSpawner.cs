using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public List<GameObject> weaponPrefabs = new List<GameObject>();
    public float rotationSpeed = 0.35f;
    public int spawnChance = 15;
    public GameObject spawnedWeapon = null;
    bool bobbing = false;

    private void Update()
    {
        if (!bobbing)
        {
            return;
        }

        gameObject.transform.Rotate(0, rotationSpeed, 0);

    }

    [Button]
    public void WeaponSpawn()
    {
        if(Random.Range(1, 101) <= spawnChance)
        {
            retry:
            var spawnedIndex = Random.Range(0, weaponPrefabs.Count);
            spawnedWeapon = weaponPrefabs[spawnedIndex];
            var currentWeapon = GameObject.Find("GunAnchorPoint").gameObject.transform.GetChild(0).gameObject;
            if (WeaponName(spawnedWeapon.name) == WeaponName(currentWeapon.name))
            {
                goto retry;
            }
            var weapon = Instantiate(weaponPrefabs[spawnedIndex], gameObject.transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            bobbing = true;
        }
    }

    string WeaponName(string weapon)
    {
        if (weapon.Contains("("))
        {
            weapon = weapon.Split('(')[0];
        }

        return weapon;
    }

}
