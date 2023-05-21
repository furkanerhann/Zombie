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
    [HideInInspector] public Animator anim;
    public EnemyHealth enemyHealth;
    public float detectionRadius = 10f;

    /* Enemy Zombie AI In Unity */
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        enemyHealth = GetComponent<EnemyHealth>();
        Target = GameObject.Find("Player");
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
    }
    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // void Movement()
    // {
    //     // Hedefin algılama mesafesinde olup olmadığını kontrol et
    //     float distanceToTarget = Vector3.Distance(transform.position, Target.transform.position);
    //     if (distanceToTarget <= detectionRadius)
    //     {
    //         // Karakteri takip etmek için uygun işlemleri gerçekleştir
    //         // Vector3 direction = Target.transform.position - transform.position;
    //         // direction.y = 0f;
    //         // transform.rotation = Quaternion.LookRotation(direction);

    //         transform.LookAt(Target.transform);
    //         transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //         // Düşmanın karakteri takip etmesi için diğer hareket kodlarını buraya ekleyebilirsiniz
    //     }
    //     if (enemyHealth.health <= 0)
    //     {
    //         anim.SetBool("isDeath", true);
    //         if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
    //         {

    //             transform.position = new Vector3(transform.position.x, 19.238f, transform.position.z);
    //         }
    //     }
    //     else
    //     {
    //         // transform.LookAt(Target.transform);
    //         // transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //     }
    // }


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