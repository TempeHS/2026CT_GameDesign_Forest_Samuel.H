using UnityEngine;

public class Death_Barrier : MonoBehaviour
{
    public GameObject deathScreen; // Assign in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            other.gameObject.SetActive(false); // Hide player
            Time.timeScale = 0f; // Freeze game (optional)
        }
    }
}