using Unity.VisualScripting;
using UnityEngine;

public class AimGunScript : MonoBehaviour
{
    public float speed = 15f;
    bool inRight = true;
    PlayerMovementScript player;
    GameObject gun;

    private void Start()
    {
        player = gameObject.transform.parent.GetComponent<PlayerMovementScript>();
        gun = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        Debug.Log(gameObject.transform.rotation.eulerAngles.z);
        if(inRight && Mathf.Abs(WrapAngle(gameObject.transform.rotation.eulerAngles.z)) > 90)
        {
            gun.transform.Rotate(180, 0, 0);
            inRight = false;
        }else if(!inRight && Mathf.Abs(WrapAngle(gameObject.transform.rotation.eulerAngles.z)) < 90)
        {
            gun.transform.Rotate(180, 0, 0);
            inRight = true;
        }

        Vector2 direction;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}
