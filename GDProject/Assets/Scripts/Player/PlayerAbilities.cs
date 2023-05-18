using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public AbilityScript ability1;
    [NonSerialized]
    public bool abilityOnCooldown1 = false;
    public AbilityScript ability2;
    [NonSerialized]
    public bool abilityOnCooldown2 = false;

    Image cooldown1;
    Image cooldown2;

    float currentCooldown1 = 0f;
    float currentCooldown2 = 0f;

    private void Start()
    {
        GameObject.Find("ImageAbility1").GetComponent<Image>().sprite = ability1.abilitySprite;
        GameObject.Find("ImageAbility2").GetComponent<Image>().sprite = ability2.abilitySprite;
        cooldown1 = GameObject.Find("CooldownAbility1").GetComponent<Image>();
        cooldown2 = GameObject.Find("CooldownAbility2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown1 > 0)
        {
            currentCooldown1 -= Time.deltaTime;
        }
        else
        {
            currentCooldown1 = 0;
        }
        cooldown1.fillAmount = UpdateValue(currentCooldown1, ability1.cooldown);

        if (currentCooldown2 > 0)
        {
            currentCooldown2 -= Time.deltaTime;
        }
        else
        {
            currentCooldown2 = 0;
        }
        cooldown2.fillAmount = UpdateValue(currentCooldown2, ability2.cooldown);

        if (!abilityOnCooldown1 && Input.GetButtonDown("Ability1")){
            currentCooldown1 = ability1.cooldown;
            StartCoroutine(ability1.UseAbility(1, gameObject));
        }

        if (!abilityOnCooldown2 && Input.GetButtonDown("Ability2"))
        {
            currentCooldown2 = ability2.cooldown;
            StartCoroutine(ability2.UseAbility(2, gameObject));
        }
    }

    public float UpdateValue(float currentValue, float maxValue)
    {
        float newValue = currentValue/maxValue;
        return newValue;
    }
}
