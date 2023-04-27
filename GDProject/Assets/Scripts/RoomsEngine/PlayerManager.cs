using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject character;
    public float health;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
