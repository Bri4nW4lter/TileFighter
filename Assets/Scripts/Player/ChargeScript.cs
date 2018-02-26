using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    public Image currentChargeBar;
    private static float minCharge = 0;
    private float charge = minCharge;
    public float maxCharge = 5f;
    public GameObject chargePrefab;
    public Transform chargeSpawn;

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

            GameObject chargeBullet = (GameObject)Instantiate(chargePrefab, chargeSpawn.position, chargeSpawn.rotation);

            Debug.Log("2");
            chargeBullet.GetComponent<Rigidbody>().velocity = chargeBullet.transform.forward * 3f;
            Destroy(chargeBullet, 5);
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
