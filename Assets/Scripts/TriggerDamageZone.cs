﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 0;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Heal", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
