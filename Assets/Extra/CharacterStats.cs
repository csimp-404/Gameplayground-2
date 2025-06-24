using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower;
    public int defense;
    public float moveSpeed;

    private void Awake()
    {
        currentHealth = maxHealth; // Initialize health
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage - defense, 0);
        currentHealth -= damageTaken;
        Debug.Log($"{gameObject.name} took {damageTaken} damage! Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject); // Temporary death logic
    }
}
