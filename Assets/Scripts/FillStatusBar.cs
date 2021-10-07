using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public Health playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth; // gets % of health remaining

        if (slider.value <= slider.minValue) // will delete small bit of health remaining in health bar when reaching zero health
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled) // will re-enable health bar UI when health is above minimum health (zero)
        {
            fillImage.enabled = true;
        }

        
        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red; // sets color to red when below 1/3 health
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green; // sets color to green when above 1/3 health
        }

        slider.value = fillValue;
    }
}
