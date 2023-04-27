using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public int normal;
    public int reversed;
    public float waitTime;
    float waitTimeCounter;
    PlatformEffector2D effector;

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
        if (Input.GetButtonUp("HoldDown"))
        {
            effector.rotationalOffset = normal;
            waitTimeCounter = waitTime;
        }

        if (Input.GetButton("HoldDown"))
        {
            if(waitTimeCounter < 0)
            {
                effector.rotationalOffset = reversed;
                waitTimeCounter = waitTime;
            }
            else
            {
                waitTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector.rotationalOffset = normal;
            waitTimeCounter = waitTime;
        }
    }
}
