using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	

    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    ChargeScript chargeScript;
    int direction;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;


    void Start()
    {
        FindFirstTile();
        GetComponent<ChargeScript>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            chargeScript.ChargeAttack();

        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;

        Destroy(bullet, 2);
    }

    public void UpButton()
    {
        direction = 0;
        Move();
    }
    public void DownButton()
    {
        direction = 1;
        Move();
    }
    public void LeftButton()
    {
        direction = 2;
        Move();
    }
    public void RightButton()
    {
        direction = 3;
        Move();
    }

     void FindFirstTile()
    {
        firstTile = GameObject.Find("Arena/Player1Tile4");
        startingTile = firstTile.GetComponent<TileScript>();
    }

    

    private void Move()
    {
        TileScript finalTile = null;            //tile we want to arrive at
        
        if (currentTile == null)
        {
            finalTile = startingTile;
        }
        else
        {
            finalTile = currentTile.NextTiles[direction];       //direction: 0 = up,    1=down,   2=left,   3=right
        }

        if (finalTile == null)
        {
            return;
        }

        //Move to Position of the Tile
        transform.position = finalTile.transform.position;
        currentTile = finalTile;
    }
}
