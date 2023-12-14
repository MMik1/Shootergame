using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth;
    private int currentHealth;

    public FloatingHealthBar floatingHealthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Ensure that you have assigned the FloatingHealthBar component to the enemy GameObject
        floatingHealthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        floatingHealthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    private void Die()
    {
        // Perform any death-related actions here
        Destroy(gameObject);
    }
}