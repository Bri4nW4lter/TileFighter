using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    public Image currentChargeBar;
    private static float minCharge = 0;
    public float charge = minCharge;
    private float maxCharge = 5f;
    public GameObject chargePrefab;
    public Transform chargeSpawn;

    // Use this for initialization
    void Start () {
        UpdateChargeBar();
    }

    public void ChargeAttack()
    {
        if (charge == maxCharge)
        {
            GameObject chargeBullet = (GameObject)Instantiate(chargePrefab, chargeSpawn.position, chargeSpawn.rotation);
            chargeBullet.GetComponent<Rigidbody>().velocity = chargeBullet.transform.forward * 3f;
            Destroy(chargeBullet, 5);
            charge = 0;
            UpdateChargeBar();
        }

    }

    public void UpdateChargeBar()
    {
        float ratio = (minCharge + charge) / maxCharge;
        currentChargeBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    //if Boss gets damaged, increase charge
    private void TakeDamage(float damage)
    {
        charge++;
        if (charge > maxCharge)
        {
            charge = maxCharge;
        }
        UpdateChargeBar();
    }
}
