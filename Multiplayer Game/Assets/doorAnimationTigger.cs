using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimationTigger : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        //animator = GetComponent<Animator>();
        animator.SetBool("open", false);
        animator.SetBool("Close", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        animator.SetBool("open", true);
        animator.SetBool("Close", false);
    }
    public void OnTriggerExit(Collider other)
    {
        animator.SetBool("Close", true);
        animator.SetBool("open", false);
    }
}
