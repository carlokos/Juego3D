using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Detect_player : MonoBehaviour
{
    private bool inRange;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI txtInteract;
    [SerializeField] private string msg;
    [SerializeField] private bool interactable;

    private void Start()
    {
        if (interactable)
        {
            anim = GetComponent<Animator>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            txtInteract.text = msg;
            if (interactable && Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("Activate");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            txtInteract.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            txtInteract.gameObject.SetActive(false);
        }
    }
}
