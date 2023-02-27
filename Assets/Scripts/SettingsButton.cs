using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public void SettingButtonPressed()
    {
        Debug.Log("Setting");
        SceneManager.LoadScene(1);
    }
}
