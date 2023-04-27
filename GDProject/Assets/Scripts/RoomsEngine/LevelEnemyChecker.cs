using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemyChecker : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    bool waiting = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if(!waiting && enemies.Count <= 0)
        {
            TriggerEndLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            if(enemies.Contains(collision.gameObject))
            {
                enemies.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                if (!enemies.Contains(collision.gameObject))
                {
                    enemies.Add(collision.gameObject);
                }
            }
        }
    }

    void TriggerEndLevel()
    {
        var weaponSpawner = GameObject.Find("WeaponSpawner").GetComponent<WeaponSpawner>();
        if(weaponSpawner != null)
        {
            weaponSpawner.WeaponSpawn();
        }

        var exitDoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        if(exitDoor != null)
        {
            exitDoor.TriggerDoorOpen();
        }

        waiting = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        waiting = false;
    }
}
