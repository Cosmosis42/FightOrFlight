using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSelection : MonoBehaviour {

    public void ChangeToScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void Test()
    {
        Debug.Log("Button Click");
    }
}
