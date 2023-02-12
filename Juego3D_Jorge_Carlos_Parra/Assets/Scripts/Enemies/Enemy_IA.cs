using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_IA : MonoBehaviour
{
    private int rutina;
    private float cronometro;
    private Animator anim;
    private Quaternion angulo;
    private float grado;

    [SerializeField] private NavMeshAgent agente;
    [SerializeField] private float radio_vision;

    [SerializeField] private float speed;
    private GameObject target;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }
    private void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radio_vision)
        {
            agente.enabled = false;
            anim.SetBool("Run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    anim.SetBool("Walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;

            agente.enabled = true;
            agente.SetDestination(target.transform.position);
            if (!inRange)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }

    public void Attacking()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        inRange = false;
        agente.speed = 0;
        yield return new WaitForSeconds(2.50f);
        inRange = true;
        agente.speed = 2.5f;
    }
}
