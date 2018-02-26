using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image currentHealthbar;
    private static float maxHealth = 100;
    private float health = maxHealth;
    ChangeScene changeScene;



    private void Start()
    {
        UpdateHealthbar();

    }

    private void Update()
    {
        Death();
    }

    void Death()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void UpdateHealthbar()
    {
        float ratio = health / maxHealth;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("taken Damage");
        if(health < 0)
        {
            health = 0;
            Debug.Log("dead");
        }
        UpdateHealthbar();
    }

    private void Heal(float damage)
    {
        health += damage;
        if (health > 0)
        {
            health = maxHealth;
        }
        UpdateHealthbar();
    }
}
