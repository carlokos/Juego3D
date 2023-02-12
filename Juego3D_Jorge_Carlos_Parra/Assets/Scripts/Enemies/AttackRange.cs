using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Enemy_IA ia;

    private void Start()
    {
        ia = GetComponentInParent<Enemy_IA>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ia.Attacking();
            GetComponentInParent<Enemy_basic>().makeAttackAnimation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ia.Attacking();
            GetComponentInParent<Enemy_basic>().makeAttackAnimation();
        }
    }
}
