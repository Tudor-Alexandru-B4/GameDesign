using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public bool replanishHealth = true;
    public int levelsTillBoss = 5;
    public TextMeshProUGUI counterText;

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

    public void AddLevel()
    {
        levelsTillBoss++;
        counterText.text = levelsTillBoss.ToString();
    }

    public void RemoveLevel()
    {
        if(levelsTillBoss > 1)
        {
            levelsTillBoss--;
        }
        counterText.text = levelsTillBoss.ToString();
    }
}
