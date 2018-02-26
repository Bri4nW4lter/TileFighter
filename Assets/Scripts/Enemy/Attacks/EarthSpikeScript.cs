using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpikeScript : MonoBehaviour {


    public GameObject[] CornerTiles;
    public GameObject EarthSpikeObject;
    public GameObject EarthWarningObject;
    private float EDeleteTime = 0.5f;
    private float EDelayTime = 0.4f;

    private void DestroyEarthDelayed()
    {
        GameObject[] earthToDestroy = GameObject.FindGameObjectsWithTag("EarthAttack");
        foreach (GameObject target in earthToDestroy)
        {
            GameObject.Destroy(target, EDeleteTime);
        }
    }

    public void EarthSpike()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(EarthWarningObject, CornerTiles[i].transform.position, CornerTiles[i].transform.rotation);

        }
        Invoke("EarthSpikeAttack", EDelayTime);
    }

    void EarthSpikeAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(EarthSpikeObject, CornerTiles[i].transform.position, CornerTiles[i].transform.rotation);
            DestroyEarthDelayed();
        }
    }


}
