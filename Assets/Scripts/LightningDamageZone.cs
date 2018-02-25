using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamageZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 20;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Heal", damage);
        }
    }
}
