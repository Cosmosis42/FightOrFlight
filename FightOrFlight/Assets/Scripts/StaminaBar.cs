using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {

    int staminaBar1;
    int staminaBar2;
    int lives1;
    int lives2;

    public bool flightMode;
 


    void Winner(int i)
    {

    }

    public GameObject StaminaIndicator;


    public Transform Container;

    public void Initialize(float maxStamina)
    {
            GameObject indicator = Instantiate(StaminaIndicator);
            indicator.transform.SetParent(Container, false);
    }

    public void SetStamina(float currentStamina)
    {
        //do stuff later
    }

}