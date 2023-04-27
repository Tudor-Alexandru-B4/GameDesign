using System;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public AbilityScript ability1;
    [NonSerialized]
    public bool abilityOnCooldown1 = false;
    public AbilityScript ability2;
    [NonSerialized]
    public bool abilityOnCooldown2 = false;


    // Update is called once per frame
    void Update()
    {
        if (!abilityOnCooldown1 && Input.GetButtonDown("Ability1")){
            StartCoroutine(ability1.UseAbility(1, gameObject));
        }

        if (!abilityOnCooldown2 && Input.GetButtonDown("Ability2"))
        {
            StartCoroutine(ability2.UseAbility(2, gameObject));
        }
    }
}
