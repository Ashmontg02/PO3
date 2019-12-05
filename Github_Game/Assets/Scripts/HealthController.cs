using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health;
    public float stamina;
    public float minHealth;
    public float minStamina;
    public float maxHealth;
    public float maxStamina;

    public Slider healthSlider;
    public Slider staminaSlider;

    SongController songController;

    void Update()
    {
        healthSlider.value = health;
        staminaSlider.value = stamina;
    }

    void Start()
    {
        healthSlider.minValue = minHealth;
        staminaSlider.minValue = minStamina;
    }
}
