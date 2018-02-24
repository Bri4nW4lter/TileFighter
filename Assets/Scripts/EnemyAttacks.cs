using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Everything for FireAttack

    public GameObject[] CrossTiles;
    public GameObject FireObject;
    public GameObject FireWarningObject;
    public float FDeleteTime = 0.5f;
    public float FDelayTime = 0.4f;

    private void DestroyFireDelayed()
    {
        GameObject[] fireToDestroy = GameObject.FindGameObjectsWithTag("FireAttack");
        foreach(GameObject target in fireToDestroy)
        {
            GameObject.Destroy(target, FDeleteTime);
        }
    }
   
   

    public void FireCross()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(FireWarningObject, CrossTiles[i].transform.position, CrossTiles[i].transform.rotation);
           
        }
        Invoke("FireCrossAttack", FDelayTime);
    }

    public void FireCrossAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(FireObject, CrossTiles[i].transform.position, CrossTiles[i].transform.rotation);
            DestroyFireDelayed();
        }
    }


    //Everything for Lightning Strike

    public GameObject[] LightningImpactZone01;
    public GameObject[] LightningImpactZone02;
    public GameObject LightningObject;
    public GameObject LightningWarning;
    public float LDelayTime = 0.4f;
    public float WaitBetweenStrikes = 1.0f;
    public float LDeleteTime = 0.2f;

    private void DestroyLightningDelayed()
    {
        GameObject[] lightningToDestroy = GameObject.FindGameObjectsWithTag("LightningAttack");
        foreach (GameObject target in lightningToDestroy)
        {
            GameObject.Destroy(target, LDeleteTime);
        }
    }

    public void LightningStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(LightningWarning, LightningImpactZone01[i].transform.position, LightningImpactZone01[i].transform.rotation);
          
        }
        Invoke("FirstStrike", LDelayTime);
    }

    void FirstStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(LightningObject, LightningImpactZone01[i].transform.position, LightningImpactZone01[i].transform.rotation);
            DestroyLightningDelayed();
        }
        Invoke("SecondStrikeWarning", WaitBetweenStrikes);     
    }
    void SecondStrikeWarning()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(LightningWarning, LightningImpactZone02[i].transform.position, LightningImpactZone02[i].transform.rotation);

        }
        Invoke("SecondStrike", LDelayTime);
    }
    void SecondStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(LightningObject, LightningImpactZone02[i].transform.position, LightningImpactZone02[i].transform.rotation);
            DestroyLightningDelayed();
        }

    }

}
