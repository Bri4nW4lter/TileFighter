using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;
        Destroy(bullet, 2);
    }

    public void ShootButton()
    {
        Shoot();
    }
}
