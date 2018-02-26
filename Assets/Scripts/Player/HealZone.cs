using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

    public TileScript healTile;
    private float HDeleteTime = 2.0f;
    public GameObject HealZoneObject;
    public GameObject healCharge;
    private float localCharge;

    void Start()
    {
        localCharge = healCharge.GetComponent<ChargeScript>().charge; 
    }

    void Update()
    {
        localCharge = healCharge.GetComponent<ChargeScript>().charge;
    }


    private void DestroyHealDelayed()
    {
        GameObject[] healToDestroy = GameObject.FindGameObjectsWithTag("HealField");
        foreach (GameObject target in healToDestroy)
        {
            GameObject.Destroy(target, HDeleteTime);
        }
    }

    public void SpawnHealZone()
    {
        if(localCharge >= 5.0f)
        {

            Instantiate(HealZoneObject, healTile.transform.position, healTile.transform.rotation);
            DestroyHealDelayed();
            localCharge = 0;
            healCharge.GetComponent<ChargeScript>().charge = localCharge ;
            healCharge.GetComponent<ChargeScript>().UpdateChargeBar();
        }


    }
        
        
    }
    



