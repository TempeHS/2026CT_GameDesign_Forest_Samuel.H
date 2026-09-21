using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;           
    public Transform spawnPoint;        
    public HealthBarScript healthBar;
    public GameObject winScreen;

    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

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
        winScreen.SetActive(false);
        Time.timeScale = 1f;

    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game2");
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

}


