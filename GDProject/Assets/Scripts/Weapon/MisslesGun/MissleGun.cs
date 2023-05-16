using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleGun : WeaponScript
{
    public float fireRate;
    public float bulletSpeed;
    public float bulletDamage;
    public float despawnTime;

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
        GameObject missleGameObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        missleGameObject.GetComponent<Missle>().damage = bulletDamage;
        missleGameObject.GetComponent<Missle>().speed = bulletSpeed;
        missleGameObject.GetComponent<Missle>().waitTime = despawnTime;
        missleGameObject.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed * Time.deltaTime;
        yield return new WaitForSecondsRealtime(fireRate);
        player.canShoot = true;
    }
}
