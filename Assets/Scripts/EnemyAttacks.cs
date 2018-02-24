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

    public GameObject[] CrossTiles;
    public GameObject FireObject;
    public float DeleteTime = 0.5f;

    private void DestroyFireDelayed()
    {
        Destroy(FireObject, DeleteTime);
    }
    public void FireCross()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(FireObject, CrossTiles[i].transform.position, CrossTiles[i].transform.rotation);
            DestroyFireDelayed();
        }
    }



}
