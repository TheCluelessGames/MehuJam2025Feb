using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenAttack_anims : MonoBehaviour
{
    [SerializeField] Animator animatorCiken;
    [SerializeField] Animator animatorGril;
    private Animator animator;
    public void FightingLoop ()
    {
        animatorCiken.Play("Ciken_attack");
        animatorGril.Play("BadGril_IsAttacked");
        animator.Play("Ending_Idle");
    }
}
