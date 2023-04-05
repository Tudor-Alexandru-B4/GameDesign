using System.Collections;
using UnityEngine;

public class BallAbility : AbilityScript
{
    public float cooldown;
    public GameObject ball;
    public float ballSpeed;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        GameObject ballGameObject = Instantiate(ball, player.transform.position, player.transform.rotation);
        ballGameObject.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * ballSpeed;
        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
