using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health;
    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log("Hit");
            if (health <= 0) EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Debug.Log("Death");
    }
}
