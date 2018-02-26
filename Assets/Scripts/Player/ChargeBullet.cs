using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBullet : MonoBehaviour {

    public bool isDamaging;
    public float damage = 0;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Heal", damage);

            Destroy(gameObject);
        }


    }
}
