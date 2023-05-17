using System.Collections.Generic;
using UnityEngine;

public class AbilityEngine : MonoBehaviour
{
    public float timeBetweenAbilities;
    public List<BossAbility> abilities = new List<BossAbility>();

    float cooldown;

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            ChooseAbility();
            cooldown = timeBetweenAbilities;
        }
    }

    void ChooseAbility()
    {
        int abilityIndex = Random.Range(0, abilities.Count);
        abilities[abilityIndex].UseAbility();
    }
}
