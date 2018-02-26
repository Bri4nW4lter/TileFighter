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
    public float BurstAttackSpeed = 2.0f;
    public FireCrossScript enemyFire;
    public LightningStrikeScript enemyLightning;
    public EarthSpikeScript enemyEarthSpike;
    public MagicMissile magicMissile;
    public BurstAttackScript burstAttack;
    public Material hatMaterial;
    public GameObject bossHealth;
    private float stageHealth=200;
    
   

    // Use this for initialization
    void Start () {
        GetComponent<FireCrossScript>();
        GetComponent<LightningStrikeScript>();
        GetComponent<EarthSpikeScript>();
        GetComponent<MagicMissile>();
        FindFirstTile();
        defSpeed = EnemySpeed;
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


    //Movement and Attacks

    void EnemyBehavior()
    {
        int stage=2;
        if (stageHealth >= 175)
        {
            stage = 2;
        }
        if (stageHealth >= 150 && stageHealth < 175)
        {
            stage = 3;
        }
        if (stageHealth >= 125 && stageHealth < 150)
        {
            stage = 4;
        }

        if (stageHealth >= 100 && stageHealth <= 125)
        {
            stage = 5;
        }

        Debug.Log(stage);


        direction = Random.Range(0, 5);

        if (direction == 4)
        {
                       
            EnemySpeed = AttackSpeed;
            attacks = Random.Range(0, stage);
            
            if(attacks == 0)
            {
                HatChangeColor(Color.magenta);
                Debug.Log("Attack!");
                magicMissile.Attack();
            }

            if(attacks == 1)
            {
                HatChangeColor(Color.red);
                Debug.Log("FireCrossAttack!");
                enemyFire.FireCross();
            }

            if (attacks == 2)
            {
                HatChangeColor(Color.cyan);
                enemyLightning.LightningStrike();
                Debug.Log("LightningStrike!");
            }

            if (attacks == 3)
            {
                HatChangeColor(Color.grey);
                Debug.Log("EarthSpike!");
                enemyEarthSpike.EarthSpike();
            }

            if (attacks == 4)
            {
                HatChangeColor(Color.white);
                Debug.Log("LaserBurst!");
                EnemySpeed = BurstAttackSpeed;                      // boss needs to cooldown --> player can do lot of damage after heavy attack
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
