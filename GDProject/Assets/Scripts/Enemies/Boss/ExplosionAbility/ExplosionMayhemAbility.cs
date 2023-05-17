using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class ExplosionMayhemAbility : BossAbility
{
    public float damage;
    public float warmingTime;
    public int numberOfExplosions;
    public float timeBetweenExplosions;
    public GameObject explosionPrefab;

    int currentExplosions = 0;
    ExplosionEnvironment explosionEnvironment;

    // Start is called before the first frame update
    void Start()
    {
        explosionEnvironment = GameObject.Find("ExplosionAbilityEnvironment").GetComponent<ExplosionEnvironment>();
    }

    [Button]
    override
    public void UseAbility()
    {
        float x = Random.Range(explosionEnvironment.ExplosionTopLeft.position.x, explosionEnvironment.ExplosionTopRight.position.x);
        float y = Random.Range(explosionEnvironment.ExplosionTopLeft.position.y, explosionEnvironment.ExplosionBottomLeft.position.y);

        var explosion = Instantiate(explosionPrefab, new Vector3(x, y, -0.75f), Quaternion.identity);
        explosion.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        explosion.gameObject.GetComponent<BossExplosion>().damage = damage;
        explosion.gameObject.GetComponent<BossExplosion>().warningTime = warmingTime;

        currentExplosions++;
        if(currentExplosions < numberOfExplosions)
        {
            StartCoroutine(WaitForRock());
        }
        else
        {
            currentExplosions = 0;
        }
    }

    IEnumerator WaitForRock()
    {
        yield return new WaitForSeconds(timeBetweenExplosions);
        UseAbility();
    }
}
