using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public void Attack()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2f;
        Destroy(bullet, 4);
    }
}
