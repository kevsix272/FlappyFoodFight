using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    // Tilldela kollisionsljudet via Inspector.
    public AudioClip collisionClip;

    // Referens till AudioSource-komponenten.
    private AudioSource audioSource;

    private void Awake()
    {
        // Hämta AudioSource från GameObjectet.
        audioSource = GetComponent<AudioSource>();

        // Om inga AudioSource finns, lägg till en.
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Anropas när en kollision sker.
    private void OnCollisionEnter(Collision collision)
    {
        // Kontrollera om det kolliderande objektet har taggen "Plaper".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Spela ljudklippet en gång vid kollisionen.
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
