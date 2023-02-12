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
    [SerializeField] private CanvasGroup BGStaminaBar;
    [SerializeField] private Image lifeBar;
    [SerializeField] private CanvasGroup BGlifeBar;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = (float)GameManager.instance.stamina / GameManager.instance.maxStamina;
        lifeBar.fillAmount = (float)GameManager.instance.life / GameManager.instance.maxLife;
    }
}
