using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour {



    public TileScript startingTile;
    public GameObject firstTile;
    TileScript currentTile;
    int direction;
    int attacks;
    public float enemySpeed = 0.35f;
    private float defSpeed;
    private float attackSpeed = 2.0f;
    private float burstAttackSpeed = 7.0f;
    public FireCrossScript enemyFire;
    public LightningStrikeScript enemyLightning;
    public EarthSpikeScript enemyEarthSpike;
    public MagicMissile magicMissile;
    public BurstAttackScript burstAttack;
    public Material hatMaterial;
    public GameObject bossHealth;
    private float stageHealth;
    
   

    // Use this for initialization
    void Start () {
        GetComponent<FireCrossScript>();
        GetComponent<LightningStrikeScript>();
        GetComponent<EarthSpikeScript>();
        GetComponent<MagicMissile>();
        FindFirstTile();
        defSpeed = enemySpeed;
        StartCoroutine("Interval");
        stageHealth = bossHealth.GetComponent<BossHealth>().health;

    }

     void FindFirstTile()
    {
        firstTile = GameObject.Find("Arena/EnemyTile4");
        startingTile = firstTile.GetComponent<TileScript>();
      
    }

    // Update is called once per frame
    void Update ()
    {
        stageHealth= bossHealth.GetComponent<BossHealth>().health;
    }

    void ResetSpeed()
    {
        enemySpeed = defSpeed;
    }

    //How often Boss Moves
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(0.5f);

        while(true)
        {
            ResetSpeed();
            EnemyBehavior();
            yield return new WaitForSeconds(enemySpeed);
        }
    }

    void HatChangeColor(Color color)
    {
        hatMaterial.color = color;
    }


    //Movement and Attacks

    void EnemyBehavior()
    {

        // Set Stage depending on Boss Health
        int stage =1;

        if (stageHealth >= 175)
        {
            stage = 1;
        }
        if (stageHealth >= 150 && stageHealth < 175)
        {
            stage = 2;
        }
        if (stageHealth >= 125 && stageHealth < 150)
        {
            stage = 3;
        }

        if (stageHealth >= 100 && stageHealth < 125)
        {
            stage = 4;
        }
        if (stageHealth < 100)
        {
            stage = 5;
        }


        //Choose to move in which direction or to attack 

        direction = Random.Range(0, 5);

        if (direction == 4)
        {        
            enemySpeed = attackSpeed;
            attacks = Random.Range(0, stage);

            if(attacks == 0)
            {
                HatChangeColor(Color.magenta);
                magicMissile.Attack();
            }

            if(attacks == 1)
            {
                HatChangeColor(Color.red);
                enemyFire.FireCross();
            }

            if (attacks == 2)
            {
                HatChangeColor(Color.cyan);
                enemyLightning.LightningStrike();
            }

            if (attacks == 3)
            {
                HatChangeColor(Color.grey);
                enemyEarthSpike.EarthSpike();
            }

            if (attacks == 4)
            {
                HatChangeColor(Color.white);
                enemySpeed = burstAttackSpeed;                      // boss needs to cooldown --> player can do lot of damage after heavy attack
                burstAttack.BurstAttack();                  
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
            finalTile = currentTile.NextTiles[direction];       //directions: 0 = up,    1=down,   2=left,   3=right     4=stand still to attack
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
