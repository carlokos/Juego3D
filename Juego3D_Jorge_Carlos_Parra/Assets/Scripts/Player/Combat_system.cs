using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_system : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Collider weaponHitbox;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("hit1");
        }

        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Block", true);
        }
        else
        {
            anim.SetBool("Block", false);
        }
    }

    public void DesactivateHitbox()
    {
        weaponHitbox.enabled = false;
    }

    public void ActivarHitbox()
    {
        weaponHitbox.enabled = true;
    }
}
