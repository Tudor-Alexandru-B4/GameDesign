using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGunScript : WeaponScript
{
    public float fireRate;
    public float bulletSpeed;
    public float bulletDamage;
    public Transform firePoint;
    public GameObject bullet;
    public List<GameObject> specialBullet = new List<GameObject>();
    public int specialBulletChance;

    GameObject choosenBullet;
    ShootingScript player;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        choosenBullet = bullet;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    override
    public IEnumerator Shoot()
    {
        player.canShoot = false;
        GameObject bulletGameObject = Instantiate(choosenBullet, firePoint.position, firePoint.rotation);
        bulletGameObject.GetComponent<BaseCardBullet>().damage = bulletDamage;
        bulletGameObject.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);

        ReloadCard();
        yield return new WaitForSecondsRealtime(fireRate);
        player.canShoot = true;
    }

    void ReloadCard()
    {
        if (Random.Range(1, 101) <= specialBulletChance)
        {
            int choosenNumber = Random.Range(0, specialBullet.Count);
            choosenBullet = specialBullet[choosenNumber];
        }
        else
        {
            choosenBullet = bullet;
        }
        spriteRenderer.color = choosenBullet.GetComponent<SpriteRenderer>().color;
    }
}
