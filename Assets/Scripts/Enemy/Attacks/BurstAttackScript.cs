using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAttackScript : MonoBehaviour {

    public GameObject horizontalLaser;
    public GameObject verticalLaser;
    public GameObject burstWarning;
    public GameObject[] burst01;
    public GameObject[] burst02;
    public GameObject[] burst03;
    public GameObject[] burst04;
    public GameObject[] burst05;

    private float bDelayTime = 0.4f;
    private float warningDeleteTime = 0.2f;
    private float bDeleteTime = 0.7f;
    private float waitBetweenBursts = 0.6f;
    private float finaleDeleteTime = 1.1f;

    private void DestroyWarningDelayed()
    {
        GameObject[] BurstToDestroy = GameObject.FindGameObjectsWithTag("LaserWarning");
        foreach (GameObject target in BurstToDestroy)
        {
            GameObject.Destroy(target, warningDeleteTime);
        }
    }

    private void DestroyBurstDelayed()
    {
        GameObject[] BurstToDestroy = GameObject.FindGameObjectsWithTag("LaserAttack");
        foreach (GameObject target in BurstToDestroy)
        {
            GameObject.Destroy(target, bDeleteTime);
        }
    }

    private void DestroyFinalDelayed()
    {
        GameObject[] FinaleToDestroy = GameObject.FindGameObjectsWithTag("LaserAttack");
        foreach (GameObject target in FinaleToDestroy)
        {
            GameObject.Destroy(target, finaleDeleteTime);
        }
    }

    //Wave1
    public void BurstAttack()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(burstWarning, burst01[i].transform.position,burst01[i].transform.rotation);
        }
        DestroyWarningDelayed();
        Invoke("FirstBurst", bDelayTime);
    }

    void FirstBurst()
    { 
        Instantiate(horizontalLaser, burst01[0].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(horizontalLaser, burst01[1].transform.position, Quaternion.Euler(0, 0, 0));
        DestroyBurstDelayed();
        Invoke("SecondWarning", waitBetweenBursts);
    }


    //Wave2
    void SecondWarning()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(burstWarning, burst02[i].transform.position, burst02[i].transform.rotation);
            DestroyWarningDelayed();
        }
        Invoke("SecondBurst", bDelayTime);
    }

    void SecondBurst()
    {
        Instantiate(horizontalLaser, burst02[0].transform.position, Quaternion.Euler(0, 0, 0));
        DestroyBurstDelayed();
        Invoke("ThirdWarning", waitBetweenBursts);
    }

    //Wave3
    void ThirdWarning()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(burstWarning, burst03[i].transform.position, burst03[i].transform.rotation);

        }
        DestroyWarningDelayed();
        Invoke("ThirdBurst", bDelayTime);
    }

    void ThirdBurst()
    {
        Instantiate(horizontalLaser, burst03[0].transform.position, Quaternion.Euler(0, -90, 0));
        Instantiate(horizontalLaser, burst03[1].transform.position, Quaternion.Euler(0, -90, 0));
        DestroyBurstDelayed();
        Invoke("FourthWarning", waitBetweenBursts);
    }

    //Wave4
    void FourthWarning()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(burstWarning, burst04[i].transform.position, burst04[i].transform.rotation);
        }
        DestroyWarningDelayed();
        Invoke("FourthBurst", bDelayTime);
    }
    void FourthBurst()
    {
        Instantiate(horizontalLaser, burst04[0].transform.position, Quaternion.Euler(0, -90, 0));
        DestroyBurstDelayed();
        Invoke("FinalWarning", waitBetweenBursts);
    }

    //Finish
    void FinalWarning()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(burstWarning, burst05[i].transform.position, burst05[i].transform.rotation);
            DestroyWarningDelayed();
        }
        Invoke("FinalBurst", bDelayTime);
    }
    void FinalBurst()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(verticalLaser, burst05[i].transform.position, burst05[i].transform.rotation);
            DestroyFinalDelayed();
        }  
    }
}

