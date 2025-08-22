using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina")]

    public Image StaminaBar;    
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float currentStamina;   
    [SerializeField] private float staminaRegenRate = 5f;    

    private void Start()
    {
        currentStamina = maxStamina;
    }
    private void Update()
    {
        RegenerateStamina();
    }

    private void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;

            if (currentStamina > maxStamina)
            {                
                currentStamina = maxStamina;
            }
        }        
    }
}
