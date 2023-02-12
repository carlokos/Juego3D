using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon_behaviour : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoseHealth(damage);
        }
    }
}
