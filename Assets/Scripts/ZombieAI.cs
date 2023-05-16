using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;
    // Start is called before the first frame update

    public Transform playerTransform;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Target = GameObject.Find("Player");
        // transform.LookAt(Target.transform);
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);

        agent.destination = playerTransform.position;
    }
}
