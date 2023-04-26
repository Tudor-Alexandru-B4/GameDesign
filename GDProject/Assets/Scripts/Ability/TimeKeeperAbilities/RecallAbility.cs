using System.Collections;
using UnityEngine;

public class RecallAbility : AbilityScript
{
    public float cooldown;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        PlayerEchosManagement echos = player.GetComponent<PlayerEchosManagement>();
        echos.isRecalling = true;
        echos.Recall();
        yield return new WaitForSecondsRealtime(cooldown);
        echos.isRecalling = false;
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
