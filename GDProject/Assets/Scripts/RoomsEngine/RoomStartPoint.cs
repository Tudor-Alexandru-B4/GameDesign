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
    }
}
