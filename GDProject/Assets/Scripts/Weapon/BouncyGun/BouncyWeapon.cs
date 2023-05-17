using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWeapon : WeaponScript
{
    public float fireRate;
    public float bulletSpeed;
    public float bulletDamage;
    public int maxBounce;
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
        GameObject bulletGameObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletGameObject.GetComponent<BouncyBullet>().damage = bulletDamage;
        bulletGameObject.GetComponent<BouncyBullet>().maxBounce = maxBounce;
        bulletGameObject.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
        yield return new WaitForSecondsRealtime(fireRate);
        player.canShoot = true;
    }
}
