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
    private Coroutine mCoroutineHideBars;
    private Coroutine mCoroutineShowBars;
    //[SerializeField] private Image lifeBar;
    //[SerializeField] private CanvasGroup BGlifeBar;

    private void Start()
    {
        BGStaminaBar.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = (float)GameManager.instance.stamina / GameManager.instance.maxStamina;

        //Mostrar y ocultar barra de stamina
        if (staminaBar.fillAmount < 1)
            mCoroutineShowBars = StartCoroutine(mCourtineShowingBars());
        else if(staminaBar.fillAmount >= 1)
            mCoroutineHideBars = StartCoroutine(mCoroutineHidingBars());
    }

    //Cuando las barras no se esten usando se ocultaran para una mejor visualización
    private IEnumerator mCoroutineHidingBars()
    {
        if(mCoroutineShowBars != null)
        {
            Debug.Log("Se para la couritina showingbars");
            StopCoroutine(mCoroutineShowBars);
            mCoroutineShowBars = null;
        }

        yield return new WaitForSeconds(0.7f);
        while (BGStaminaBar.alpha >= 0)
        {
            BGStaminaBar.alpha -= 0.05f;
            yield return new WaitForSeconds(0.2f);
        }
        mCoroutineHideBars = null;
    }

    //Cuando se esten usando las barras se mostraran al jugador
    private IEnumerator mCourtineShowingBars()
    {
        if (mCoroutineHideBars != null)
        {
            Debug.Log("Se para la couritina hidingbars");
            StopCoroutine(mCoroutineHideBars);
            mCoroutineHideBars = null;
        }

        while(BGStaminaBar.alpha <= 1)
        {
            BGStaminaBar.alpha += 0.05f;
            yield return new WaitForSeconds(0.2f);
        }
        mCoroutineShowBars = null;
    }
}
