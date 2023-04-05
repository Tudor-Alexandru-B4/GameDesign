using System.Collections;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
    public virtual IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        yield return new WaitForSecondsRealtime(0f);
    }

    protected void changeCooldownBoolForAbility(int abilityNumber, GameObject player)
    {
        PlayerAbilities playerAbilities = player.GetComponent<PlayerAbilities>();
        if(abilityNumber == 1)
        {
            playerAbilities.abilityOnCooldown1 = !playerAbilities.abilityOnCooldown1;
            return;
        }

        if (abilityNumber == 2)
        {
            playerAbilities.abilityOnCooldown2 = !playerAbilities.abilityOnCooldown2;
        }
    }
}
