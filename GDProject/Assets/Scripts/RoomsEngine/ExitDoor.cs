using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    bool roomFinished = false;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var tempColor = spriteRenderer.color;
        tempColor.a = 0f;
        spriteRenderer.color = tempColor;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Minus))
        {
            FinishSequence();
        }
    }

    public void TriggerDoorOpen()
    {
        roomFinished = true;
        var tempColor = spriteRenderer.color;
        tempColor.a = 1f;
        spriteRenderer.color = tempColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(roomFinished && collision.tag == "Player")
        {
            if (Input.GetButton("HoldDown"))
            {
                GameObject.Find("PlayerManager").GetComponent<PlayerManager>().health = collision.GetComponent<HealthSystemPlayer>().health;
                FinishSequence();
            }
        }
    }

    private void FinishSequence()
    {
        roomFinished = false;
        var playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerManager.roomNumber++;
        if (playerManager.roomNumber == playerManager.roomsUntilBoss)
        {
            SceneManager.LoadScene("BossBattleScene");
            return;
        }

        if (playerManager.roomNumber > playerManager.roomsUntilBoss)
        {
            SceneManager.LoadScene("EndScene");
            return;
        }

        var index = Random.Range(0, playerManager.scenes.Count);
        SceneManager.LoadScene(playerManager.scenes[index]);

        //int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        //string path = SceneUtility.GetScenePathByBuildIndex(index);
        //string sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
        //SceneManager.LoadScene(sceneName);
    }
}
