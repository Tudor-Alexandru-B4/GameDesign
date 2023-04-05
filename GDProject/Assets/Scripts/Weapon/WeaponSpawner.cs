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
            var spawnedIndex = Random.Range(0, weaponPrefabs.Count);
            spawnedWeapon = weaponPrefabs[spawnedIndex];
            var weapon = Instantiate(weaponPrefabs[spawnedIndex], gameObject.transform);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
            bobbing = true;
        }
    }

}
