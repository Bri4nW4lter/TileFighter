using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour {



    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    int direction;
    public float EnemySpeed = 0.3f;
    public float defSpeed;
    public float AttackSpeed = 1.0f;


    // Use this for initialization
    void Start () {
        FindFirstTile();
        defSpeed = EnemySpeed;
        StartCoroutine("Interval");

    }
  

     void FindFirstTile()
    {
        firstTile = GameObject.Find("Arena/EnemyTile4");
        startingTile = firstTile.GetComponent<TileScript>();
    }

    // Update is called once per frame
    void Update () {
      
	}

    void ResetSpeed()
    {
        EnemySpeed = defSpeed;
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(0.5f);

        while(true)
        {
            ResetSpeed();

            EnemyBehavior();
            yield return new WaitForSeconds(EnemySpeed);
        }
    }

    

    void EnemyBehavior()
    {
        direction = Random.Range(0, 5);

        if (direction == 4)
        {
            Debug.Log("Attack");
            EnemySpeed = AttackSpeed;
        }

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
