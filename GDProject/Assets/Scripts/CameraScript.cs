using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float offset;
    public float offsetY = 0f;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        var playerPos = player.transform.position;
        var newX = playerPos.x + (player.GetComponent<PlayerMovementScript>().facingRight ? -1 : 1) * offset;
        gameObject.transform.position = new Vector3(newX, playerPos.y + offsetY, gameObject.transform.position.z);
    }
}
