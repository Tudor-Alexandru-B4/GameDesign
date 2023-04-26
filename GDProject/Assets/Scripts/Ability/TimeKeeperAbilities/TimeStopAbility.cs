using System.Collections;
using UnityEngine;

public class TimeStopAbility : AbilityScript
{
    public float cooldown;
    public float timeStopDuration;
    TimeStopRange timeStopRange;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        GameObject checker = player.transform.Find("TimeStopRange").gameObject;
        timeStopRange = checker.GetComponent<TimeStopRange>();
        timeStopRange.TimeStop(timeStopDuration);
        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
