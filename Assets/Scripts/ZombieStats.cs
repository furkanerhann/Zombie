using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    public float attackSpeed;
    [SerializeField] private bool canAttack;
    [HideInInspector] public Animator anim;
    private NavMeshAgent agent = null;
    private bool death = true;
    private void Start()
    {
        InitVariables();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();

        agent.enabled = false;
        anim.SetBool("death", true);

        Destroy(gameObject, 3f);
    }
    public override void InitVariables()
    {
        maxHealth = 100;
        SetHealthInfo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }
    public override void CheckHealth()
    {

        if (health <= 0)
        {
            if (death)
            {
                death = false;
                EnemySpawner.zombieCount--;
                PlayerHUD.instance.UpdateScoreAmount();
            }
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
}
