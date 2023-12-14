using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Hier kun je de code plaatsen om naar de "died" scene te gaan
        StartCoroutine(LoadDiedScene());
    }

    IEnumerator LoadDiedScene()
    {
        yield return new WaitForSeconds(0.5f); // Pas de vertraging naar wens aan
        SceneManager.LoadScene(2);
    }
}