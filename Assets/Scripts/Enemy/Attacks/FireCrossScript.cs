using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrossScript : MonoBehaviour {



    public GameObject[] CrossTiles;
    public GameObject FireObject;
    public GameObject FireWarningObject;
    public float FDeleteTime = 0.5f;
    public float FDelayTime = 0.4f;

    private void DestroyFireDelayed()
    {
        GameObject[] fireToDestroy = GameObject.FindGameObjectsWithTag("FireAttack");
        foreach (GameObject target in fireToDestroy)
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

}
