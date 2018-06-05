using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : Singleton<GameUI> {

    public Text shoots;
    public Text level;
    public Text par;

    public int[] Par =
    {
        2,3
    };

   

    private int lvlCounter = 0;
    public void FullFillGameUIData()
    {
        lvlCounter++;
        shoots.text = "0";
        level.text = lvlCounter.ToString();
        par.text = Par[lvlCounter-1].ToString();
    }

    public void NullShoots()
    {
        shoots.text = "0";
    }

    public void AddShoot()
    {
        int current = int.Parse(shoots.text);
        current++;
        shoots.text = current.ToString();
    }

    public void AddLevel()
    {
        int current = int.Parse(level.text);
        current++;
        level.text = current.ToString();
    }

    private void Start()
    {
        FullFillGameUIData();
    }
}
