using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAttackScript : MonoBehaviour {

    public GameObject HorizontalLaser;
    public GameObject VerticalLaser;
    public GameObject BurstWarning;
    public GameObject[] Burst01;
    public GameObject[] Burst02;
    public GameObject[] Burst03;
    public GameObject[] Burst04;
    public GameObject[] Burst05;

    public float BDelayTime = 0.4f;
    public float WarningDeleteTime = 0.2f;
    public float BDeleteTime = 0.7f;
    public float WaitBetweenBursts = 0.6f;
    public float FinaleDeleteTime = 1.1f;

    private void DestroyWarningDelayed()
    {
        GameObject[] BurstToDestroy = GameObject.FindGameObjectsWithTag("LaserWarning");
        foreach (GameObject target in BurstToDestroy)
        {
            GameObject.Destroy(target, WarningDeleteTime);
        }
    }

    private void DestroyBurstDelayed()
    {
        GameObject[] BurstToDestroy = GameObject.FindGameObjectsWithTag("LaserAttack");
        foreach (GameObject target in BurstToDestroy)
        {
            GameObject.Destroy(target, BDeleteTime);
        }
    }

    private void DestroyFinalDelayed()
    {
        GameObject[] FinaleToDestroy = GameObject.FindGameObjectsWithTag("LaserAttack");
        foreach (GameObject target in FinaleToDestroy)
        {
            GameObject.Destroy(target, FinaleDeleteTime);
        }
    }

    //Wave1
    public void BurstAttack()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(BurstWarning, Burst01[i].transform.position,Burst01[i].transform.rotation);

        }
        DestroyWarningDelayed();
        Invoke("FirstBurst", BDelayTime);
    }

    void FirstBurst()
    {
        
        Instantiate(HorizontalLaser, Burst01[0].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(HorizontalLaser, Burst01[1].transform.position, Quaternion.Euler(0, 0, 0));
        DestroyBurstDelayed();
        Invoke("SecondWarning", WaitBetweenBursts);
    }


    //Wave2
    void SecondWarning()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(BurstWarning, Burst02[i].transform.position, Burst02[i].transform.rotation);
            DestroyWarningDelayed();
        }
        Invoke("SecondBurst", BDelayTime);
    }

    void SecondBurst()
    {
        Instantiate(HorizontalLaser, Burst02[0].transform.position, Quaternion.Euler(0, 0, 0));
        DestroyBurstDelayed();
        Invoke("ThirdWarning", WaitBetweenBursts);

    }

    //Wave3
    void ThirdWarning()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(BurstWarning, Burst03[i].transform.position, Burst03[i].transform.rotation);

        }
        DestroyWarningDelayed();
        Invoke("ThirdBurst", BDelayTime);

    }

    void ThirdBurst()
    {
        Instantiate(HorizontalLaser, Burst03[0].transform.position, Quaternion.Euler(0, -90, 0));
        Instantiate(HorizontalLaser, Burst03[1].transform.position, Quaternion.Euler(0, -90, 0));
        DestroyBurstDelayed();
        Invoke("FourthWarning", WaitBetweenBursts);

    }

    //Wave4
    void FourthWarning()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(BurstWarning, Burst04[i].transform.position, Burst04[i].transform.rotation);

        }
        DestroyWarningDelayed();
        Invoke("FourthBurst", BDelayTime);

    }
    void FourthBurst()
    {
        Instantiate(HorizontalLaser, Burst04[0].transform.position, Quaternion.Euler(0, -90, 0));
        DestroyBurstDelayed();
        Invoke("FinalWarning", WaitBetweenBursts);

    }
    //Finish
    void FinalWarning()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(BurstWarning, Burst05[i].transform.position, Burst05[i].transform.rotation);
            DestroyWarningDelayed();
        }
        Invoke("FinalBurst", BDelayTime);

    }
    void FinalBurst()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(VerticalLaser, Burst05[i].transform.position, Burst05[i].transform.rotation);
            DestroyFinalDelayed();
        }
        

    }

}

