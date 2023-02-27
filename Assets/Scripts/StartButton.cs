using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartButtonPressed()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(2);
    }
}
