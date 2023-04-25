using System.Collections;
using UnityEngine;

public class DiceRollAbility : AbilityScript
{
    public float cooldown;
    public float throwSpeed;
    public float throwRotation;
    public float rollTime;
    public float waitTime;
    public GameObject dice;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        GameObject diceObject = Instantiate(dice, player.transform.position, player.transform.rotation);
        diceObject.GetComponent<DiceRoll>().rollTime = rollTime;
        diceObject.GetComponent<DiceRoll>().waitTime = waitTime;
        diceObject.gameObject.GetComponent<Rigidbody2D>().AddForce(player.transform.right * throwSpeed);
        diceObject.gameObject.GetComponent<Rigidbody2D>().AddTorque(throwRotation, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
