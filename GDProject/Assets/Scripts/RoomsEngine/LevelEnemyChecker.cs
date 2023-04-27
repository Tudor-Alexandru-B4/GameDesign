using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnemyChecker : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    bool waiting = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if(!waiting && enemies.Count <= 0)
        {
            TriggerEndLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            if(enemies.Contains(collision.gameObject))
            {
                enemies.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !collision.name.StartsWith("ExplosiveBarrel"))
        {
            List<IHealthSystem> interfaceList;
            DamageUtils.GetInterfaces<IHealthSystem>(out interfaceList, collision.gameObject);
            foreach (IHealthSystem healthSystem in interfaceList)
            {
                if (!enemies.Contains(collision.gameObject))
                {
                    enemies.Add(collision.gameObject);
                }
            }
        }
    }

    void TriggerEndLevel()
    {
        int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        string sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        waiting = false;
    }
}
