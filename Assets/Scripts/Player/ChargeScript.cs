using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    public Image currentChargeBar;
    private static float minCharge = 0;
    private float charge = minCharge;
    public float maxCharge = 5f;
    public TileScript[] ChargeTiles;

    // Use this for initialization
    void Start () {
        UpdateChargeBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChargeAttack();
        }
    }

    public void ChargeAttack()
    {
        if (charge == maxCharge)
        {
            Debug.Log("pew");

            //chargeattack
            charge = 0;
            UpdateChargeBar();
        }

    }



    private void UpdateChargeBar()
    {
        float ratio = (minCharge + charge) / maxCharge;
        currentChargeBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        charge++;
        Debug.Log("Power up");
        if (charge > maxCharge)
        {
            charge = maxCharge;
            Debug.Log("maxCharge");
        }
        UpdateChargeBar();
    }
}
