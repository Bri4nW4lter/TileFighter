using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrossScript : MonoBehaviour {

    public GameObject[] crossTiles;
    public GameObject fireObject;
    public GameObject fireWarningObject;
    private float fDeleteTime = 0.5f;
    private float fDelayTime = 0.4f;

    private void DestroyFireDelayed()
    {
        GameObject[] fireToDestroy = GameObject.FindGameObjectsWithTag("FireAttack");
        foreach (GameObject target in fireToDestroy)
        {
            GameObject.Destroy(target, fDeleteTime);
        }
    }

    public void FireCross()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(fireWarningObject, crossTiles[i].transform.position, crossTiles[i].transform.rotation);
        }
        Invoke("FireCrossAttack", fDelayTime);
    }

    public void FireCrossAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(fireObject, crossTiles[i].transform.position, crossTiles[i].transform.rotation);
            DestroyFireDelayed();
        }
    }

}
