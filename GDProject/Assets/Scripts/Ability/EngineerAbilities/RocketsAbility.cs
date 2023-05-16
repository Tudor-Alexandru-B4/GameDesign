using System.Collections;
using UnityEngine;

public class RocketsAbility : AbilityScript
{
    public float cooldown;
    public float damage;
    public GameObject rocket;
    public float rocketSpeedMiddle;
    public float rocketSpeedSides;
    public float rocketSpeedMargins;
    public float offset = 0.5f;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);

        var rocketPosition1 = player.transform.position;
        rocketPosition1.y += offset;
        GameObject rocketGameObject0 = Instantiate(rocket, rocketPosition1, player.transform.rotation);
        rocketGameObject0.GetComponent<BasicBulletScript>().damage = damage;
        rocketGameObject0.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * rocketSpeedSides;

        rocketPosition1.y += offset;
        GameObject rocketGameObject1 = Instantiate(rocket, rocketPosition1, player.transform.rotation);
        rocketGameObject1.GetComponent<BasicBulletScript>().damage = damage;
        rocketGameObject1.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * rocketSpeedMargins;

        GameObject rocketGameObject2 = Instantiate(rocket, player.transform.position, player.transform.rotation);
        rocketGameObject2.GetComponent<BasicBulletScript>().damage = damage;
        rocketGameObject2.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * rocketSpeedMiddle;

        var rocketPosition3 = player.transform.position;
        rocketPosition3.y -= offset;
        GameObject rocketGameObject3 = Instantiate(rocket, rocketPosition3, player.transform.rotation);
        rocketGameObject3.GetComponent<BasicBulletScript>().damage = damage;
        rocketGameObject3.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * rocketSpeedSides;

        rocketPosition3.y -= offset;
        GameObject rocketGameObject4 = Instantiate(rocket, rocketPosition3, player.transform.rotation);
        rocketGameObject4.GetComponent<BasicBulletScript>().damage = damage;
        rocketGameObject4.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * rocketSpeedMargins;

        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
