using System.Collections;
using UnityEngine;

public class ClockGun : WeaponScript
{
    public float fireRate;
    public float bulletSpeed;
    public float bulletDamage;

    public float recallDistance;
    public float recallSpeed;
    public float increaseSize;

    public Transform firePoint;
    public GameObject bullet;

    private ShootingScript player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
    }

    override
    public IEnumerator Shoot()
    {
        player.canShoot = false;
        GameObject clockGameObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        clockGameObject.GetComponent<Clock>().damage = bulletDamage;
        clockGameObject.GetComponent<Clock>().recallDistance = recallDistance;
        clockGameObject.GetComponent<Clock>().recallSpeed = recallSpeed;
        clockGameObject.GetComponent<Clock>().increaseSize = increaseSize;
        clockGameObject.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
        yield return new WaitForSecondsRealtime(fireRate);
        player.canShoot = true;
    }
}
