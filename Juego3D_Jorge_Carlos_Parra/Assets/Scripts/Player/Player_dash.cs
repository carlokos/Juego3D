using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_dash : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerCam;
    private Player_Mov playerMov;

    [Header("Dashing")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float staminaCost;

    [Header("Cooldown")]
    [SerializeField] private float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    private KeyCode dashKey = KeyCode.E;

    private void Start()
    {
        playerMov = GetComponent<Player_Mov>();
    }

    private void Update()
    {
        if(dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(dashKey) && dashCdTimer <= 0)
        {
            dashCdTimer = dashCd;
            GameManager.instance.LoseStamina(staminaCost);
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashDuration)
        {
            playerMov.Controller.Move(playerMov.Move * dashForce * Time.deltaTime);
            yield return null;
        }
    }
}
