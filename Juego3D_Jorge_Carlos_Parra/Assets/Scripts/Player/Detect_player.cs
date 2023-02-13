using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Detect_player : MonoBehaviour
{
    private bool inRange;
    [SerializeField] private TextMeshProUGUI txtPickItem;
    [Header("ItemChoise")]
    [SerializeField] private bool isRedPotion;
    [SerializeField] private bool isGreenPotion;


    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            txtPickItem.gameObject.SetActive(false);
            if (isRedPotion)
            {
                GameManager.instance.maxLife += 10;
                GameManager.instance.life = GameManager.instance.maxLife;
            }

            if (isGreenPotion)
            {
                GameManager.instance.maxStamina += 60;
                GameManager.instance.stamina = GameManager.instance.maxStamina;
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            txtPickItem.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            txtPickItem.gameObject.SetActive(false);
        }
    }
}
