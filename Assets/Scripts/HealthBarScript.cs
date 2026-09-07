using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        if (slider == null)
        {
            Debug.LogError("HealthBarScript: No Slider assigned or found on this GameObject.");
        }
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    void Start()
    {
        SetMaxHealth(100);
    }


    public void TakeDamage(int damage)
    {
        var newHealth = slider.value - damage;
        slider.value = newHealth;

        if (slider.value == 0)
        {
            Debug.Log("Player is dead!");
        }
    }
}
