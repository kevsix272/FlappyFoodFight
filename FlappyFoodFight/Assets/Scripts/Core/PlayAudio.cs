using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This function will be triggered by the animation event
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
