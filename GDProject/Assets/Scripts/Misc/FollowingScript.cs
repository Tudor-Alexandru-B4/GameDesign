using UnityEngine;

public class FollowingScript : MonoBehaviour
{
    public GameObject toFollow = null;

    // Update is called once per frame
    void Update()
    {
        if(toFollow != null)
        {
            transform.position = toFollow.transform.position;
        }
    }
}
