using UnityEngine;

public class RoomStartPoint : MonoBehaviour
{
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        GameObject player = Instantiate(playerManager.character, transform.position, Quaternion.identity);
        player.GetComponent<HealthSystemPlayer>().health = playerManager.health;
    }
}
