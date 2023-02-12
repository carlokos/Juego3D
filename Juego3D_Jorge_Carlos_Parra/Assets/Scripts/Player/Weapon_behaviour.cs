using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_behaviour : MonoBehaviour
{
    [SerializeField] private float damage;
    private Collider hitbox;

    private void Start()
    {
        hitbox = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy_basic>().takeDamage(damage);
        }
    }
}
