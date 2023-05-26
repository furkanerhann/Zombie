using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public WeaponManager weapon;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<ZombieStats>())
        {
            CharacterStats enemyStats = collision.gameObject.GetComponentInParent<CharacterStats>();
            enemyStats.TakeDamage(weapon.damage);
        }
        Destroy(this.gameObject);
    }
}
