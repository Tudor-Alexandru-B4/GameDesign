using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            Destroy(player);
        }

        Instantiate(characters[Random.Range(0, characters.Count)], transform.position, Quaternion.identity);
    }
}
