using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_camera_animation : MonoBehaviour
{
    [SerializeField] private Animator DoorAnimator;
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
        animator.SetTrigger("Options");
    }
}
