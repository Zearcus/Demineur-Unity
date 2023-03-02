using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public void SettingButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
