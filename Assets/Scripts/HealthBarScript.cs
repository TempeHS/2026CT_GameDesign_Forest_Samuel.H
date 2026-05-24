using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    /// <summary>
    ///  Slider value represents our current health
    /// </summary>
    Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    void Start()
    {
        SetMaxHealth(100);
    }


    void TakeDamage(int damage)
    {
        var newHealth = slider.value - damage;
        slider.value = newHealth;

        // Am I Dead?
    }

    // public void SetHealth(int health)
    // {
    //     slider.value = health;
    // }
}
