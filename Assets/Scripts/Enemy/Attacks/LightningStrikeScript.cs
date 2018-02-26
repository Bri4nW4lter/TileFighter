using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeScript : MonoBehaviour {

    public GameObject[] lightningImpactZone01;
    public GameObject[] lightningImpactZone02;
    public GameObject lightningObject;
    public GameObject lightningWarning;
    private float lDelayTime = 0.7f;
    private float waitBetweenStrikes = 0.2f;
    private float lDeleteTime = 0.2f;

    private void DestroyLightningDelayed()
    {
        GameObject[] lightningToDestroy = GameObject.FindGameObjectsWithTag("LightningAttack");
        foreach (GameObject target in lightningToDestroy)
        {
            GameObject.Destroy(target, lDeleteTime);
        }
    }

    public void LightningStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(lightningWarning, lightningImpactZone01[i].transform.position, lightningImpactZone01[i].transform.rotation);
        }
        Invoke("FirstStrike", lDelayTime);
    }

    void FirstStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(lightningObject, lightningImpactZone01[i].transform.position, lightningImpactZone01[i].transform.rotation);
            DestroyLightningDelayed();
        }
        Invoke("SecondStrikeWarning", waitBetweenStrikes);
    }
    void SecondStrikeWarning()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(lightningWarning, lightningImpactZone02[i].transform.position, lightningImpactZone02[i].transform.rotation);
        }
        Invoke("SecondStrike", lDelayTime);
    }
    void SecondStrike()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(lightningObject, lightningImpactZone02[i].transform.position, lightningImpactZone02[i].transform.rotation);
            DestroyLightningDelayed();
        }
    }
}
