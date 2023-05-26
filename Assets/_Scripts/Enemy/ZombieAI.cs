using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;
    // Start is called before the first frame update
    [SerializeField] float gravity = -9.81f;
    CharacterController controller;
    #region GroundCheck
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    #endregion
    Vector3 velocity;
    public EnemyHealth enemyHealth;
    public float detectionRadius = 10f;

    /* Enemy Zombie AI In Unity */
    [SerializeField] private float stoppingDistance = 3;
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    [HideInInspector] public Animator anim;
    private ZombieStats stats = null;
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
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
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        // enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<ZombieStats>();
    }

    public bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y + controller.radius - 0.08f, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }
}