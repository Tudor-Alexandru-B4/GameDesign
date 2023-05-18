using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int roomNumber = 0;
    public bool replanishHealth = true;
    public GameObject character;
    public float health;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
