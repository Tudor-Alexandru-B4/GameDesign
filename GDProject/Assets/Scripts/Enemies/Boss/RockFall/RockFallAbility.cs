using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class RockFallAbility : BossAbility
{
    public float damage;
    public int numberOfRocks;
    public float waitBetweenRocks;
    public GameObject rockPrefab;

    int currentRocksSpawned = 0;
    RockEnvironment rockEnvironment;
    
    // Start is called before the first frame update
    void Start()
    {
        rockEnvironment = GameObject.Find("RockAbilityEnvironment").GetComponent<RockEnvironment>();
    }

    [Button]
    override
    public void UseAbility()
    {
        float y = rockEnvironment.RockSpawnLeft.position.y;
        float x = Random.Range(rockEnvironment.RockSpawnLeft.position.x, rockEnvironment.RockSpawnRight.position.x);
        var rock = Instantiate(rockPrefab, new Vector3(x, y, -0.75f), Quaternion.identity);
        rock.gameObject.GetComponent<RockDamage>().damage = damage;
        rock.gameObject.GetComponent<RockDamage>().minY = rockEnvironment.RockDespawn.position.y;

        currentRocksSpawned++;
        if(currentRocksSpawned < numberOfRocks)
        {
            StartCoroutine(WaitForRock());
        }
        else
        {
            currentRocksSpawned = 0;
        }
    }

    IEnumerator WaitForRock()
    {
        yield return new WaitForSeconds(waitBetweenRocks);
        UseAbility();
    }
}
