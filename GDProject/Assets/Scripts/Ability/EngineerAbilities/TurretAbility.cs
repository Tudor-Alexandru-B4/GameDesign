using System.Collections;
using UnityEngine;

public class TurretAbility : AbilityScript
{
    public GameObject turret;
    public float turretTime;

    override
    public IEnumerator UseAbility(int abilityNumber, GameObject player)
    {
        changeCooldownBoolForAbility(abilityNumber, player);
        GameObject turretSpawned = Instantiate(turret, player.transform.position, new Quaternion(0.342020094f, 0.939692676f, 0f, 0f));
        turretSpawned.GetComponent<EngineerTurret>().spawnTime = turretTime;
        yield return new WaitForSecondsRealtime(cooldown);
        changeCooldownBoolForAbility(abilityNumber, player);
    }
}
