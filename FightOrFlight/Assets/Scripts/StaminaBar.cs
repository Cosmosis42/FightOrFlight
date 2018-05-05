using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class StaminaBar
{
	public Slider StaminaSlider;

	public void Initialize(float maxStamina)
	{
		StaminaSlider.maxValue = maxStamina;
		StaminaSlider.value = maxStamina;
	}

	public void SetStamina(float currentStamina)
	{
		StaminaSlider.value = currentStamina;
	}
}

