using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {

    int staminaBar1;
    int staminaBar2;
    int lives1;
    int lives2;

    public bool flightMode;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (lives1 == 0)
        {
            Winner(2);
        }
        if (lives2 == 0)
        {
            Winner(1);
        }


        if (!flightMode)
        {

        }
        else
        {

        }
    }


    void Winner(int i)
    {

    }

}