using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image currentHealthbar;
    private float health = 100;
    private float maxHealth = 100;

    private void Start()
    {
        UpdateHealthbar();

    }

    private void UpdateHealthbar()
    {
        float ratio = health / maxHealth;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
            Debug.Log("dead");
        }
        UpdateHealthbar();
    }
}
