using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu_camera_animation : MonoBehaviour
{
    [SerializeField] private Animator DoorAnimator;
    [SerializeField] private GameObject[] panels;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Play");
        DoorAnimator.SetTrigger("Open");
    }

    public void OptionsAnimation()
    {
        animator.SetBool("Options", true);
    }

    public void BackFromOptionsAnimation()
    {
        animator.SetBool("Options", false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void activarPanel(GameObject panel)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        panel.SetActive(true);
    }
}
