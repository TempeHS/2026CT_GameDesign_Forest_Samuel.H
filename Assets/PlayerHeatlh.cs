using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBarScript healthBar;
    public int maxHealth = 100;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        healthBar.TakeDamage(damage);
    }
}