using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Target = GameObject.Find("Player");
        transform.LookAt(Target.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
