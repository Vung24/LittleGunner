using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public static PlayerHealth instance;
    public GameObject dieEffect, dieEffectPosition;
    int currentHealth, numCLone = 3;
    public bool dead = false;
    public Animator animator;
    public HealthBar healthBar;
    void Start()
    {
        if (instance == null)
            instance = this;
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    void Update()
    {
        TakeDamage(0);
    }
    public void TakeDamage(int damage)
    {
        if (Player.instance.rollOnce == false)
        {
            if (currentHealth > 0)
            {
                if(currentHealth > damage)
                    currentHealth -= damage;
                else currentHealth = 0;
                healthBar.UpdateBar(currentHealth, maxHealth);
            }
            else
            {
                currentHealth = 0;
                PlayerDeath();
            }
        }
    }
    public void PlayerDeath()
    {
        animator.SetBool("Die", true);
        Player.instance.moveSpeed = 0f;
        Destroy(gameObject, 0.8f);
        Invoke("creatDieEffect", 0.7f);
        dead = true;
    }
    void creatDieEffect()
    {
        if (numCLone > 0)
        {
            Instantiate(dieEffect, dieEffectPosition.transform.position, Quaternion.identity);
            numCLone--;
        }
    }
}
