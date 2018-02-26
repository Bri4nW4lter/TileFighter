using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

    public TileScript healTile;
    private float HDeleteTime = 2.0f;
    public GameObject HealZoneObject;
    private PlayerMovement playerMovement;
    private Transform heal;
   

    private void DestroyHealDelayed()
    {
        GameObject[] healToDestroy = GameObject.FindGameObjectsWithTag("HealZone");
        foreach (GameObject target in healToDestroy)
        {
            GameObject.Destroy(target, HDeleteTime);
        }
    }

    public void SpawnHealZone()
    {
        
        Instantiate(HealZoneObject, healTile.transform.position, healTile.transform.rotation);
        DestroyHealDelayed();
    }
    


}
