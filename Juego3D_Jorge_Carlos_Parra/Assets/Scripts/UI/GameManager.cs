using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float life = 10;
    public float stamina = 100;
    public int maxStamina = 100;
    public int maxLife = 10;

    private Coroutine mCoroutineLosing;
    private Coroutine mCoroutineRecovering;
    //Singlenton 
    //
    public static GameManager instance
    {
        get; private set;
    }

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(float lost)
    {
        life -= lost;
        if(life <= 0)
        {
            Debug.Log("Muelto");
        }
    }

    public void LoseStamina(float lost)
    {
        //Desactivar recuperar stamina
        if (mCoroutineRecovering != null)
        {
            StopCoroutine(mCoroutineRecovering);
            mCoroutineRecovering = null;
        }

        if(stamina - lost > 0)
        {
            if(mCoroutineLosing != null)
            {
                StopCoroutine(mCoroutineLosing);
            }
            mCoroutineLosing = StartCoroutine(LosingStaminaCoroutine(lost));
        }
    }

    public void RecoverStamina(float recover)
    {
        //desactivamos perder stamina
        if(mCoroutineLosing != null)
        {
            StopCoroutine(mCoroutineLosing);
            mCoroutineLosing = null;
        }

        if(mCoroutineRecovering != null)
        {
            StopCoroutine(mCoroutineRecovering);
        }
        mCoroutineRecovering = StartCoroutine(RecoveringStaminaCoroutine(recover));
    }

    private IEnumerator RecoveringStaminaCoroutine(float recover)
    {
        while (stamina < maxStamina)
        {
            stamina += recover;
            yield return new WaitForSeconds(0.1f);
        }
        mCoroutineRecovering = null;
    }

    private IEnumerator LosingStaminaCoroutine(float lost)
    {
        while(stamina >= 0)
        {
            stamina -= lost;
            yield return new WaitForSeconds(0.1f);
        }
        mCoroutineLosing = null;
    }
}
