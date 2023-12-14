using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        slider.value = (float)currentHealth / maxHealth;
    }
}