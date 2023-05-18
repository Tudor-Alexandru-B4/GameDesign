using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public bool replanishHealth = true;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeValue(bool value)
    {
        replanishHealth = value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
