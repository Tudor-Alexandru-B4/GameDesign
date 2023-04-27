using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            Destroy(player);
        }

        int index = Random.Range(0, characters.Count);
        GameObject newPlayer = Instantiate(characters[index], transform.position, Quaternion.identity);
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();

        playerManager.character = characters[index];
        playerManager.health = newPlayer.GetComponent<HealthSystemPlayer>().health;
    }
}
