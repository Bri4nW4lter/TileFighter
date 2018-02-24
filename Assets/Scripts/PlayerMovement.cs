﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindFirstTile();
	}

    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    int direction;

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

    // Update is called once per frame
    void Update () {
       
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




        Debug.Log(currentTile.transform.position);

    }
}
