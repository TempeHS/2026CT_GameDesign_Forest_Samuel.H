using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
