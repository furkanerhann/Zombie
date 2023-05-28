using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public float speed = 1.5f;
    // Start is called before the first frame update
    Vector3 velocity;
    public EnemyHealth enemyHealth;
    public float detectionRadius = 10f;

    /* Enemy Zombie AI In Unity */
    [SerializeField] private float stoppingDistance = 3;
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;
    private NavMeshAgent agent = null;
    private Transform target;
    [HideInInspector] public Animator anim;
    private ZombieStats stats = null;
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            //Attack

            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }

            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }
    private void RotateToTarget()
    {
        //transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
    }

    private void GetReferences()
    {
        anim = GetComponentInParent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<ZombieStats>();
        target = MovementStateManager.instance;
    }
}