using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Combat_system : MonoBehaviour
{
    private Animator anim;
    private Player_Mov player_mov;
    private bool canShield;
    private float defaultStaminaRecovery;
    [SerializeField] private Collider weaponHitbox;
    [SerializeField] private float attackCD = 0.6f;
    public float attackCDtimer;
    [SerializeField] private float shieldingStaminaCost;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player_mov = GetComponent<Player_Mov>();
        canShield = true;
        defaultStaminaRecovery = player_mov.StaminaRecovery1;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCDtimer >= 0)
        {
            attackCDtimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && attackCDtimer <= 0)
        {
            anim.SetTrigger("hit1");
            attackCDtimer = attackCD;
        }

        if (Input.GetButton("Fire2") && canShield)
        {
            anim.SetBool("Block", true);
        }
        else
        {
            anim.SetBool("Block", false);
        }
    }

    private void FixedUpdate()
    {
        switch (GameManager.instance.stamina)
        {
            case > 0.3f:
                if (Input.GetButton("Fire2") && canShield)
                {
                    player_mov.StaminaRecovery1 = 0;
                    GameManager.instance.LoseStamina(shieldingStaminaCost);
                }
                else
                {
                    player_mov.StaminaRecovery1 = defaultStaminaRecovery;
                }

                break;

            case <= 0.3f:
                anim.SetBool("Block", false);
                player_mov.StaminaRecovery1 = defaultStaminaRecovery;
                StartCoroutine(recoveringFromShielding());
                break;
        }
    }

    private IEnumerator recoveringFromShielding()
    {
        canShield = false;
        yield return new WaitForSeconds(1.5f);
        canShield = true;
    }
    public void DesactivateHitbox()
    {
        weaponHitbox.enabled = false;
    }

    public void ActivarHitbox()
    {
        weaponHitbox.enabled = true;
    }
}
