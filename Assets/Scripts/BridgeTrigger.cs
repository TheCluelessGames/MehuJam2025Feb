using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void StartFalling()
    {
        animator.SetTrigger("Start");
    }
}
