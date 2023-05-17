using NaughtyAttributes;
using UnityEngine;

public class RocketEmporiumAbility : BossAbility
{
    public float damage;
    public float speed;
    public float warningTime;
    public float delay;
    public GameObject rocketGoingRight;
    public GameObject rocketGoingLeft;

    RocketEnvironment rocketEnvironment;

    // Start is called before the first frame update
    void Start()
    {
        rocketEnvironment = GameObject.Find("RocketAbilityEnvironment").GetComponent<RocketEnvironment>();
    }

    [Button]
    override
    public void UseAbility()
    {
        bool spawnLeft = Random.Range(0, 2) != 0;

        for(int i = 0; i < rocketEnvironment.LeftRockets.Count; i++)
        {
            GameObject rocket = null;
            float destroyX = 0f;

            if(spawnLeft)
            {
                float x = rocketEnvironment.LeftRockets[i].position.x;
                float y = rocketEnvironment.LeftRockets[i].position.y;
                destroyX = rocketEnvironment.RightRockets[i].position.x;
                rocket = Instantiate(rocketGoingRight, new Vector3(x, y, -0.75f), Quaternion.identity);
            }
            else
            {
                float x = rocketEnvironment.RightRockets[i].position.x;
                float y = rocketEnvironment.RightRockets[i].position.y;
                destroyX = rocketEnvironment.LeftRockets[i].position.x;
                rocket = Instantiate(rocketGoingLeft, new Vector3(x, y, -0.75f), Quaternion.identity);
            }
            rocket.GetComponent<BossRocket>().damage = damage;
            rocket.GetComponent<BossRocket>().warningTime = warningTime + delay * i;
            rocket.GetComponent<BossRocket>().speed = speed;
            rocket.GetComponent<BossRocket>().goesRight = spawnLeft;
            rocket.GetComponent<BossRocket>().destroyX = destroyX;

            spawnLeft = !spawnLeft;
        }

        rocketEnvironment.LeftRockets.Reverse();
        rocketEnvironment.RightRockets.Reverse();
    }
}
