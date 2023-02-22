using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private Animator door_anim;

    public void openDoors()
    {
        door_anim.SetTrigger("open");
    }
}
