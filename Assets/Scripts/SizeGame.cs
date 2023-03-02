using UnityEngine;
using UnityEngine.SceneManagement;

public class SizeGame : MonoBehaviour
{
    public void TogglePressed(int bonjour)
    {
        PlayerPrefs.SetInt("Setting",bonjour);
        Debug.Log(bonjour);
    }

    public void Awake(){
        PlayerPrefs.SetInt("Setting", 0);
    }
}

