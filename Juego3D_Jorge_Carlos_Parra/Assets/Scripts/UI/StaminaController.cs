using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{ 
    /*
      * Clase que controla la barra de Stamina y de vida, se guarda el stamina maxima y se 
      * va actualizando segun la actual
     */
    [SerializeField] private Image staminaBar;
    private float maxStamina;

    private void Start()
    {
        maxStamina = GameManager.instance.stamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = (float)GameManager.instance.stamina / maxStamina;
    }
}
