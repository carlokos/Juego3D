using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_basic : MonoBehaviour
{
    /*
     * Script que controla lo básico de un enemigo como vida, ataque y animaciones
     */
    [SerializeField] private float life;
    [SerializeField] private Collider hitbox;
    [SerializeField] private Collider attackRange;
    [SerializeField] private NavMeshAgent agente;

    private Animator anim;
    private bool canTakeDamage = true;
    private bool canAttack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hitbox.enabled = false;
        attackRange.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Deja acabar la animacion antes de volver a atacar, por si el jugador se queda cerca del enemigo
     */
    private IEnumerator isAttacking()
    {
        canAttack = false;
        anim.SetTrigger("Attack");
        agente.speed = 0;
        yield return new WaitForSeconds(2.50f);
        canAttack = true;
        agente.speed = 2.5f;
    }

    private IEnumerator damageCoroutine()
    {
        attackRange.enabled = false;
        anim.SetTrigger("Damage");
        agente.speed = 0;
        yield return new WaitForSeconds(.3f);
        attackRange.enabled = true;
        agente.speed = 2.5f;
    }

    /*
     * La mayoria de estas funcionas la llamamos desde eventos en las animaciones del enemigo, para que coincida las animaciones y los colliders
     */
    public void ActivateHitbox()
    {
        hitbox.enabled = true;
    }
    public void DesactivateHitbox()
    {
        hitbox.enabled = false;
    }

    public void makeAttackAnimation()
    {
        if (canAttack)
            StartCoroutine(isAttacking());
    }

    public void takeDamage(float damage)
    {
        life -= damage;
        if(life <= 0 && canTakeDamage)
        {
            agente.speed = 0;
            attackRange.enabled = false;
            hitbox.enabled = false;
            agente.enabled = false;
            canTakeDamage = false;
            anim.SetTrigger("Death");
            canAttack = false;
        } else if (canTakeDamage)
        {
            StartCoroutine(damageCoroutine());
        }
            
    }

    public void despawnEnemy()
    {
        Destroy(gameObject);
    }
}
