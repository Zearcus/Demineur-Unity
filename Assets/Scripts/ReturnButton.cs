using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void ReturnButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
