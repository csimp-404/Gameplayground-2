using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private Animator anim;
    private bool isDead = false;

    public MonoBehaviour movementScript;
    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log(gameObject.name + " took " + damage + " damage");

        // Play hit reaction animation
        if (anim != null)
            anim.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");

        isDead = true;

        // Play death animation if exists
        if (anim != null)
            anim.SetTrigger("Death");

        // Disable collider & movement if needed
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        if (movementScript != null)
            movementScript.enabled = false;

        // Optional: Destroy after delay
        Destroy(gameObject, 5f);
    }
}
