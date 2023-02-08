using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    [Header ("Character Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float baseSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    [Header("Jump Properties")]
    [SerializeField] private float SphereRadius = 5;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;

    [Header ("Run Properties")]
    [SerializeField] private float StaminaCost = 0.05f;
    [SerializeField] private float StaminaRecovery = 0.03f;
    [SerializeField] private float sprintSpeed = 5f;
    private float speedBoost = 1f;
    private bool canSprint = true;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        //Sprint
        if (Input.GetButton("Fire3") && canSprint)
        {
            speedBoost = sprintSpeed;
            GameManager.instance.LoseStamina(StaminaCost);
        }
        else
            speedBoost = 1f;

        //Salto
        isGrounded = Physics.CheckSphere(groundCheck.position, SphereRadius, groundMask);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
