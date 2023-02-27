using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Game game;
    public Text FlagNum;

    private void FixedUpdate()
    {
        ShowNumFlag();
    }

    void ShowNumFlag()
    {
        FlagNum.text = string.Format("{00}", game.countFlag);
    }
}
