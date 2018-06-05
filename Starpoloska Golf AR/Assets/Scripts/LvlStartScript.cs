using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlStartScript : MonoBehaviour {

    public GameObject quickMenu;
    //UI  
    public Text shoots;
    
    //objects
    public GameObject golfer;
    public GameObject ball;

    //lvl1
    public Transform startPositionGolfer;
    public Transform startPositionBall;

    //lvl2
    public Transform startPositionGolferLVL2;
    public Transform startPositionBallLVL2;

    public void StartLVL1()
    {
        golfer.transform.position = startPositionGolfer.position;
        ball.transform.position = startPositionBall.position;
    }

    public void StartLVL2()
    {
        golfer.transform.position = startPositionGolferLVL2.position;
        ball.transform.position = startPositionBallLVL2.position;
        GameUI.Instance.level.text = "2";
    }

    public void ResetLevel()
    {
        if (GameUI.Instance.level.text == "1")
        {
            //UI
            shoots.text = "0";
            //Game
            golfer.transform.position = startPositionGolfer.position;
            ball.transform.position = startPositionBall.position;
        }
        if (GameUI.Instance.level.text == "2")
        {
            //UI
            shoots.text = "0";
            //Game
            golfer.transform.position = startPositionGolferLVL2.position;
            ball.transform.position = startPositionBallLVL2.position;
        }

        quickMenu.SetActive(false);


    }


}
