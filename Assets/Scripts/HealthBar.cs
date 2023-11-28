using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Ensure the health slider is set in the Inspector or find it dynamically.
        if (healthSlider == null)
        {
            healthSlider = GetComponentInChildren<Slider>();
        }

        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Ensure health doesn't go below 0.
        currentHealth = Mathf.Max(0, currentHealth);

        UpdateHealthBar();

        // Check if the player is dead or perform other actions based on health reaching 0.
        if (currentHealth == 0)
        {
            // TODO: Handle player death or other relevant actions.
            Debug.Log("Player is dead!");
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Ensure health doesn't exceed the maximum.
        currentHealth = Mathf.Min(maxHealth, currentHealth);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Update the value of the health slider based on the current health.
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
}
