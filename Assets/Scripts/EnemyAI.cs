using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindFirstTile();
        StartCoroutine("Interval");
    }

    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    int direction;
    public float EnemySpeed = 0.5f;

  

     void FindFirstTile()
    {
        firstTile = GameObject.Find("Arena/EnemyTile4");
        startingTile = firstTile.GetComponent<TileScript>();
    }

    // Update is called once per frame
    void Update () {
      // InvokeRepeating("EnemyBehavior", 1.5f, 2.0f);
	}


    IEnumerator Interval()
    {
        yield return new WaitForSeconds(0.5f);

        while(true)
        {
            EnemyBehavior();
            yield return new WaitForSeconds(EnemySpeed);
        }
    }

    

    void EnemyBehavior()
    {
        direction = Random.Range(0, 4);
        Move();

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
            finalTile = currentTile.NextTiles[direction];       //direction: 0 = up,    1=down,   2=left,   3=right     4=stand still to attack
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
