using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonQuitPresses()
    {
        Debug.Log("bonjour");
        Application.Quit();
    }
}
