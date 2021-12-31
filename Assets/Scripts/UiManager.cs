using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text leftScoreText;
    public Text rightScoreText;
    public Text gameOverText;

    public EventSystemManager eventSystem;

    public GameManager gameManager;

    void Start()
    {
        eventSystem.OnRightGoalEnter.AddListener(UpdateLeftScore);
        eventSystem.OnLeftGoalEnter.AddListener(UpdateRightScore);
        eventSystem.OnLeftWin.AddListener(LeftPlayerWin);
        eventSystem.OnRightWin.AddListener(RightPlayerWin);
    }

    public void UpdateRightScore()
    {
        rightScoreText.text = gameManager.rightPoint.ToString();
    }

    public void UpdateLeftScore()
    {
        leftScoreText.text = gameManager.leftPoint.ToString();
    }

    public void LeftPlayerWin()
    {
        gameOverText.text = "Left Win";
    }

    public void RightPlayerWin()
    {
        gameOverText.text = "Right Win";
    }
}
