using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public Cell cell;
    public void ReturnMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

}
