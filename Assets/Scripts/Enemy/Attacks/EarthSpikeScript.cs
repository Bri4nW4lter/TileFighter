using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpikeScript : MonoBehaviour {


    public GameObject[] cornerTiles;
    public GameObject earthSpikeObject;
    public GameObject earthWarningObject;
    private float eDeleteTime = 0.5f;
    private float eDelayTime = 0.4f;

    private void DestroyEarthDelayed()
    {
        GameObject[] earthToDestroy = GameObject.FindGameObjectsWithTag("EarthAttack");
        foreach (GameObject target in earthToDestroy)
        {
            GameObject.Destroy(target, eDeleteTime);
        }
    }

    public void EarthSpike()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(earthWarningObject, cornerTiles[i].transform.position, cornerTiles[i].transform.rotation);
        }
        Invoke("EarthSpikeAttack", eDelayTime);
    }

    void EarthSpikeAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(earthSpikeObject, cornerTiles[i].transform.position, cornerTiles[i].transform.rotation);
            DestroyEarthDelayed();
        }
    }


}
