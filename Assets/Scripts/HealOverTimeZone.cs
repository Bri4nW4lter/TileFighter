using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOverTimeZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 0;

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Heal", Time.deltaTime * damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
