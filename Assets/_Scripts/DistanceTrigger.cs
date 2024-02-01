using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class DistanceTrigger : MonoBehaviour{
    public UnityEvent OnActivate;

    [SerializeField] private Transform target;

    [SerializeField] private float activationDistance = 3f;
    [SerializeField] private float resetDelay = 10f;

    [SerializeField] private string triggerName = "NextAnim";

    private Animator animator;

    private bool onCooldown = false;

    private void Awake(){
        TryGetComponent(out animator);
    }

    private void Update(){
        if (onCooldown) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < activationDistance){
            Activate();
        }
    }

    private IEnumerator ResetTimeCoroutine() {
        onCooldown = true;
        yield return new WaitForSeconds(resetDelay);
        onCooldown = false;
    }

    private void Activate() {
        animator.SetTrigger(triggerName);
        OnActivate?.Invoke();
        StartCoroutine(ResetTimeCoroutine());
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }
}
