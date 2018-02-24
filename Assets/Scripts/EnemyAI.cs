using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour {



    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    int direction;
    int attacks;
    public float EnemySpeed = 0.4f;
    public float defSpeed;
    public float AttackSpeed = 1.0f;
    public EnemyAttacks enemyAttacks;
    public Material hatMaterial;



    // Use this for initialization
    void Start () {
        GetComponent<EnemyAttacks>();
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

    void HatChangeColor(Color color)
    {
        hatMaterial.color = color;
    }



    void EnemyBehavior()
    {
        direction = Random.Range(0, 5);

        if (direction == 4)
        {
            EnemySpeed = AttackSpeed;
            attacks = Random.Range(0, 2);
            if(attacks == 0)
            {
                Debug.Log("Attack01");
                
            }

            if(attacks == 1)
            {
                HatChangeColor(Color.red);
                Debug.Log("FireCrossAttack!");
                enemyAttacks.FireCross();
            } 
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

        HatChangeColor(Color.black);
        //Move to Position of the Tile
        transform.position = finalTile.transform.position;
        currentTile = finalTile;
    }


}
