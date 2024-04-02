using UnityEngine;

public class SoundInteractable : MonoBehaviour{
    [Header("Refernces")]
    [SerializeField] private AudioClip clipToPlay;
    [SerializeField] private AudioSource audioSource;

    public void PlayClipOnInteract() {
        if (clipToPlay != null && audioSource != null){
            audioSource.PlayOneShot(clipToPlay);
        }
    }
}