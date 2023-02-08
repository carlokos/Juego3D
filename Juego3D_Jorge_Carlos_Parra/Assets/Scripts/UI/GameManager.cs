using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int life = 10;
    public float stamina = 100;
    private int maxStamina = 100;
    private int maxLife = 10;

    private Coroutine mCoroutineLosing;
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

    public void LoseHealth(int lost)
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
        if(stamina - lost > 0)
        {
            if(mCoroutineLosing != null)
            {
                StopCoroutine(mCoroutineLosing);
            }
            mCoroutineLosing = StartCoroutine(LosingStaminaCoroutine(lost));
        }
    }

    private IEnumerator LosingStaminaCoroutine(float lost)
    {
        while(stamina >= 0)
        {
            stamina -= lost;
            yield return new WaitForSeconds(0.1f);
        }
        mCoroutineLosing = null;
        //Desactivar sprint;
    }
}
