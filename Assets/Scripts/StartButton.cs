using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene(2);
    }
}
