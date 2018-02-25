using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    public Image currentChargeBar;
    private static float minCharge = 0;
    private float charge = minCharge;

    // Use this for initialization
    void Start () {

	}

    public void ChargeAttack()
    {
        if (charge ==10)
        {
            Debug.Log("pew");
        }

    }



    private void UpdateChargeBar()
    {
        currentChargeBar.rectTransform.localScale = new Vector3(charge, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        charge++;
        Debug.Log("Power up");
        if (charge > 10)
        {
            charge = 10;
            Debug.Log("maxCharge");
        }
        UpdateChargeBar();
    }
}
