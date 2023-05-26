using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetHealthInfo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterHeal = health - damage;
        SetHealthInfo(healthAfterHeal);
    }

    public virtual void InitVariables()
    {
        maxHealth = 100;
        SetHealthInfo(maxHealth);
        isDead = false;
    }
}
