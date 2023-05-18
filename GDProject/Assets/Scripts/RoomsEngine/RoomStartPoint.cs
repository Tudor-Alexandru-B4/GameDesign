using UnityEngine;

public class RoomStartPoint : MonoBehaviour
{
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        GameObject player = Instantiate(playerManager.character, transform.position, Quaternion.identity);
        if (!playerManager.replanishHealth)
        {
            player.GetComponent<HealthSystemPlayer>().health = playerManager.health;
        }

        if (playerManager.weapon)
        {
            var anchor = GameObject.Find("GunAnchorPoint").GetComponent<AimGunScript>();
            GameObject oldGun = anchor.transform.GetChild(0).gameObject;
            Destroy(oldGun);
            GameObject newGun = Instantiate(playerManager.weapon, anchor.transform);
            anchor.gun = newGun;
        }
    }
}
