using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public bool showCase = false;
    public int preferredWeapon = -1;
    public List<GameObject> weaponPrefabs = new List<GameObject>();
    public float rotationSpeed = 0.35f;
    public int spawnChance = 15;
    public GameObject spawnedWeapon = null;
    public bool bobbing = false;

    private void Start()
    {
        if(showCase)
        {
            gameObject.name = "WeaponShowcase";
            WeaponSpawn();
        }
    }

    private void Update()
    {
        if (!bobbing)
        {
            return;
        }

        if(transform.childCount > 0)
        {
            gameObject.transform.GetChild(0).Rotate(0, rotationSpeed, 0);
        }

    }

    [Button]
    public void WeaponSpawn()
    {
        if(preferredWeapon > -1 && preferredWeapon < weaponPrefabs.Count)
        {
            spawnedWeapon = weaponPrefabs[preferredWeapon];
            var weapon = Instantiate(weaponPrefabs[preferredWeapon], gameObject.transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            bobbing = true;
        }
        else if(Random.Range(1, 101) <= spawnChance)
        {
            retry:
            var spawnedIndex = Random.Range(0, weaponPrefabs.Count);
            spawnedWeapon = weaponPrefabs[spawnedIndex];
            var anchor = GameObject.Find("GunAnchorPoint");
            if (anchor != null)
            {
                var currentWeapon = anchor.gameObject.transform.GetChild(0).gameObject;
                if (WeaponName(spawnedWeapon.name) == WeaponName(currentWeapon.name))
                {
                    goto retry;
                }
            }
            var weapon = Instantiate(weaponPrefabs[spawnedIndex], gameObject.transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            bobbing = true;
        }
    }

    public void SpawnWeapon(GameObject oldGun)
    {
        string gunGame = WeaponName(oldGun.name);
        foreach(GameObject weaponPrefab in weaponPrefabs)
        {
            if(WeaponName(weaponPrefab.name) == gunGame)
            {
                spawnedWeapon = weaponPrefabs[weaponPrefabs.FindIndex(a => a == weaponPrefab)];
                var weapon = Instantiate(weaponPrefab, gameObject.transform);
                weapon.transform.localPosition = new Vector3(0, 0, 0);
                bobbing = true;
                Destroy(oldGun);
                return;
            }
        }
        Destroy(oldGun);
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
