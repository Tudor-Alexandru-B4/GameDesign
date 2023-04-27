using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEchosManagement : MonoBehaviour
{
    public float echosDistance;
    public int maxEchos;
    Queue<Vector3> echosTransform = new Queue<Vector3>();
    Queue<float> echosHealth = new Queue<float>();
    GameObject player = null;
    HealthSystemPlayer healthSystem = null;
    public bool isRecalling = false;
    bool waiting = false;

    public GameObject echosPool;
    public GameObject echoPrefab;

    int currentEchos = 0;

    private void Start()
    {
        echosPool = Instantiate(echoPrefab, new Vector3(0f, -50f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if(player != null )
            {
                healthSystem = player.GetComponent<HealthSystemPlayer>();
            }
            return;
        }

        if (!isRecalling)
        {
            if (!waiting)
            {
                StartCoroutine(EchosUpdate());
            }
        }
    }

    IEnumerator EchosUpdate()
    {
        waiting = true;

        if(currentEchos < maxEchos)
        {
            Instantiate(echoPrefab, player.transform.position, player.transform.rotation, echosPool.transform);
            currentEchos++;
        }
        else
        {
            echosTransform.Dequeue();
            echosHealth.Dequeue();
        }

        echosTransform.Enqueue(player.transform.position);
        echosHealth.Enqueue(healthSystem.health);

        var transformArray = echosTransform.ToArray();
        var HealthArray = echosHealth.ToArray();
        for (int i = 0; i < echosPool.transform.childCount; i++)
        {
            echosPool.transform.GetChild(i).position = transformArray[i];
            var echoSpriteRenderer = echosPool.transform.GetChild(i).GetComponent<SpriteRenderer>();
            echoSpriteRenderer.color = new Color(Mathf.Clamp((1 - HealthArray[i] / healthSystem.maxHealth), 0, 1), Mathf.Clamp((HealthArray[i] / healthSystem.maxHealth), 0, 1), 0, 0.5f);
        }

        yield return new WaitForSeconds(echosDistance);
        waiting = false;
    }

    public void Recall()
    {
        var transformRecall = echosTransform.Dequeue();
        var healthRecall = echosHealth.Dequeue();

        healthSystem.health = healthRecall;
        player.transform.position = transformRecall;

        echosTransform.Clear();
        echosHealth.Clear();
        foreach(Transform child in echosPool.transform)
        {
            Destroy(child.gameObject);
        }
        currentEchos = 0;
    }
}
