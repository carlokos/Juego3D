using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private Player_Mov player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        player = GameObject.Find("Player").GetComponent<Player_Mov>(); ;
    }

    public void GameOver()
    {
        player.CanMove = false;
        //playerAnim.SetTrigger("Death");
        StartCoroutine(GameOverAnimation());
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator GameOverAnimation()
    {
        while (gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
            gameObject.GetComponent<CanvasGroup>().alpha += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
