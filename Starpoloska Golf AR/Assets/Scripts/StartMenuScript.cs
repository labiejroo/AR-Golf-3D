using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : Singleton<StartMenuScript> {

    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject startMenuUI;
    public GameObject gameMenuUI;
    public GameObject winingUI;
    public drop dropScript;
    public GameObject middleTextCounter;
    public GameObject middleTextCounter2;
    public GameObject panelBlocker;

    public GameObject QuickMenu;
    public GameObject EndMenu;
    public Text score;

    private void Start()
    {

        dropScript.PlayAudio();
    }
   

    public void StartApp()
    {
        startMenuUI.SetActive(false);
        lvl1.SetActive(true);
        gameMenuUI.SetActive(true);
        dropScript.StartDrop();
        middleTextCounter.SetActive(true);
        middleTextCounter2.SetActive(true);
        drop.Instance.counter.text = "9";
        panelBlocker.SetActive(true);
    }

    public void Settings()
    {

    }

    public void TurnOffmiddleCounter()
    {
        middleTextCounter.SetActive(false);
        middleTextCounter2.SetActive(false);
    }

    public void BackToMenu()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        gameMenuUI.SetActive(false);
        winingUI.SetActive(false);

        startMenuUI.SetActive(true);
    }

    public void TurnOffWininingUI()
    {
        winingUI.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void TurnOffQuickMenu()
    {
        QuickMenu.SetActive(false);

    }

    public void TurnOnQuickMenu()
    {
        QuickMenu.SetActive(true);

    }

    public void TurnOnEndMenu()
    {
        EndMenu.SetActive(true);
        score.text = GMScript.Instance.overallPlayerScore.ToString();
    }

    public void TurnOffEndMenu()
    {
        EndMenu.SetActive(false);
    }
}
