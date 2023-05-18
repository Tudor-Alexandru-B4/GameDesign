using System.Collections;
using UnityEngine;

public class PokerChipAbility : AbilityScript
{
    public float throwSpeed;
    public float travelTime;
    public float travelSpeed;
    public float damage;
    public GameObject pockerChip;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        GameObject pokerChipObject = Instantiate(pockerChip, player.transform.position, player.transform.rotation);
        pokerChipObject.GetComponent<PokerChip>().travelTime = travelTime;
        pokerChipObject.GetComponent<PokerChip>().travelSpeed = travelSpeed;
        pokerChipObject.GetComponent<PokerChip>().damage = damage;
        pokerChipObject.GetComponent<PokerChip>().facingRight = player.GetComponent<PlayerMovementScript>().facingRight;
        pokerChipObject.gameObject.GetComponent<Rigidbody2D>().AddForce(player.transform.right * throwSpeed);
        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
