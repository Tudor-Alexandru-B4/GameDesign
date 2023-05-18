using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int roomNumber = 0;
    public bool replanishHealth = true;
    public GameObject character;
    public float health;

    private void Start()
    {
        var menuLoader = GameObject.Find("MenuLoader");
        if(menuLoader != null)
        {
            replanishHealth = menuLoader.GetComponent<MenuLoader>().replanishHealth;
        }
        
        DontDestroyOnLoad(gameObject);
    }

}
