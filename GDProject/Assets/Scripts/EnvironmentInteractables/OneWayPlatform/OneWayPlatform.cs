using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public int normal;
    public int reversed;
    public float waitTime;
    public int layer;
    float waitTimeCounter;
    PlatformEffector2D effector;

    GameObject player = null;
    int oldLayer;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        effector.rotationalOffset = normal;
        waitTimeCounter = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            if(player != null)
            {
                oldLayer = player.layer;
            }
            return;
        }

        if (Input.GetButtonUp("HoldDown"))
        {
            //effector.rotationalOffset = normal;
            player.layer = oldLayer;
            waitTimeCounter = waitTime;
        }

        if (Input.GetButton("HoldDown"))
        {
            if(waitTimeCounter < 0)
            {
                //effector.rotationalOffset = reversed;
                player.layer = layer;
                waitTimeCounter = waitTime;
            }
            else
            {
                waitTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            //effector.rotationalOffset = normal;
            player.layer = oldLayer;
            waitTimeCounter = waitTime;
        }
    }
}
