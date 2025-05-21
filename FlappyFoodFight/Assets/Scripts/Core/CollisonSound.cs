using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    // Tilldela kollisionsljudet via Inspector.
    public AudioClip collisionClip;

    // Referens till AudioSource-komponenten.
    private AudioSource audioSource;

    private void Awake()
    {
        // H�mta AudioSource fr�n GameObjectet.
        audioSource = GetComponent<AudioSource>();

        // Om inga AudioSource finns, l�gg till en.
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Anropas n�r en kollision sker.
    private void OnCollisionEnter(Collision collision)
    {
        // Kontrollera om det kolliderande objektet har taggen "Plaper".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Spela ljudklippet en g�ng vid kollisionen.
            if (collisionClip != null)
            {
                audioSource.PlayOneShot(collisionClip);
            }
            else
            {
                Debug.LogWarning("Kollisionsljudklipp inte tilldelat!");
            }
        }
    }
}
