using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAbility : AbilityScript
{
    public float cooldown;
    public GameObject ice;
    public float iceSpeedMiddle;
    public float iceSpeedSides;
    public float offset = 0.5f;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);

        var icePosition1 = player.transform.position;
        icePosition1.y += offset;
        GameObject iceGameObject1 = Instantiate(ice, icePosition1, player.transform.rotation);
        iceGameObject1.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * iceSpeedSides;

        GameObject iceGameObject2 = Instantiate(ice, player.transform.position, player.transform.rotation);
        iceGameObject2.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * iceSpeedMiddle;

        var icePosition3 = player.transform.position;
        icePosition3.y -= offset;
        GameObject iceGameObject3 = Instantiate(ice, icePosition3, player.transform.rotation);
        iceGameObject3.gameObject.GetComponent<Rigidbody2D>().velocity = player.transform.right * iceSpeedSides;

        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
