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
                roomFinished = false;
                int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
                string path = SceneUtility.GetScenePathByBuildIndex(index);
                string sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
