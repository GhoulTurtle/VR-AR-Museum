using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonAnim : MonoBehaviour{
    private const string TRIGGERNAME = "NextAnimation";

    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    public void TriggerNextAnimation() {
        animator.SetTrigger(TRIGGERNAME);
    }
}
