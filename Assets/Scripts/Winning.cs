using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    public Timer time;
    public Text winning;

    public void Start()
    {
        time= new Timer();
        time.TimeON = false;
    }
    public void Won()
    {
        winning.text = string.Format("You did " + "{0:00}" + " seconds !", time.TimeDid);
    }
}
