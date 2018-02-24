using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Heal", Time.deltaTime * damage);
        }
    }
}
