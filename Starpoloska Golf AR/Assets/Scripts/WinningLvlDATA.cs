using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Academy.HoloToolkit.Unity;


public class WinningLvlDATA : Singleton<WinningLvlDATA> {


    //GameUI
    public Text shootsCounterGameUI;
    public Text parCounterGameUI;
    public Text lvlCounterGameUI;

    //Wining UI
    public Text shootsCounter;
    public Text parCounter;
    public Text lvlCounter;
    public Text passNotPass;
    private string pass = "Congratulations ,You passed";
    private string notPass = "Too many shoots, try again";

    public void FullFillDATA()
    {
        shootsCounter.text = shootsCounterGameUI.text;
        parCounter.text = parCounterGameUI.text;
        lvlCounter.text = lvlCounterGameUI.text;

        if(int.Parse(shootsCounter.text) <= int.Parse(parCounter.text))
        {
            passNotPass.text = pass;
        }
        else
        {
            passNotPass.text = notPass;
        }
        
    }

    public void SavePlayerRecord()
    {
        if (lvlCounter.text == "1")
        {
            GMScript.Instance.overallPlayerScore = int.Parse(shootsCounter.text);
        }
        if (lvlCounter.text == "2")
        {
            GMScript.Instance.overallPlayerScore += int.Parse(shootsCounter.text);
        }
    }

    public void TurnOnEndMENU()
    {
        if (lvlCounter.text == "2")
        {
            StartMenuScript.Instance.TurnOnEndMenu();
        }
    }

}
