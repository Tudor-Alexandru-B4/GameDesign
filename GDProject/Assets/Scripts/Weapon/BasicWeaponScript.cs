using System.Collections;
using UnityEngine;

public class BasicWeaponScript : WeaponScript
{
    public float fireRate;
    public float bulletSpeed;
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
        bulletGameObject.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        yield return new WaitForSecondsRealtime(fireRate);
        player.canShoot = true;
    }
}
