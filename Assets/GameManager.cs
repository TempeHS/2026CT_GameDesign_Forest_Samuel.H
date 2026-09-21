using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;           
    public Transform spawnPoint;        
    public HealthBarScript healthBar;

    public void Die()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Respawn()
    {
        player.transform.position = spawnPoint.position;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        healthBar.SetMaxHealth(100);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;

    }

}


