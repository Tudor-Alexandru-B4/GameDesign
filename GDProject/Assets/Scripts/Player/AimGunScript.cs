using System.Linq;
using System.Net;
using UnityEngine;

public class AimGunScript : MonoBehaviour
{
    public float speed = 15f;
    bool inRight = true;
    PlayerMovementScript player;
    public GameObject gun;
    public WeaponPicker weaponPicker;

    private void Start()
    {
        player = gameObject.transform.parent.GetComponent<PlayerMovementScript>();
        gun = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetButtonDown("ChangeWeapon"))
        {
            weaponPicker.TryToPickUp(gameObject.GetComponent<AimGunScript>());
        }

        if(inRight && Mathf.Abs(WrapAngle(gameObject.transform.rotation.eulerAngles.z)) > 90)
        {
            gun.transform.Rotate(180, 0, 0);
            inRight = false;
        }else if(!inRight && Mathf.Abs(WrapAngle(gameObject.transform.rotation.eulerAngles.z)) < 90)
        {
            gun.transform.Rotate(180, 0, 0);
            inRight = true;
        }

        if (Input.GetJoystickNames().Any(e => e.Length > 0))
        {
            //Controller Control
            if (Input.GetAxis("ControllerAimX") != 0.0 || Input.GetAxis("ControllerAimY") != 0.0)
            {
                float angleController = Mathf.Atan2(-Input.GetAxis("ControllerAimX"), Input.GetAxis("ControllerAimY")) * Mathf.Rad2Deg;
                Quaternion rotationController = Quaternion.AngleAxis(angleController, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationController, speed * Time.deltaTime);
            }
            return;
        }

        //Mouse Control
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
