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
        eventSystem.winEvent.AddListener(UpdateScore);
        eventSystem.OnLeftWin.AddListener(LeftPlayerWin);
        eventSystem.OnRightWin.AddListener(RightPlayerWin);
    }

    private void UpdateScore(GoalSide goalSide)
    {
        if (goalSide == GoalSide.Left)
        {
            UpdateLeftScore();
        }
        else
        {
            UpdateRightScore();
        }
    }

    private void UpdateRightScore()
    {
        rightScoreText.text = gameManager.rightPoint.ToString();
    }

    private void UpdateLeftScore()
    {
        leftScoreText.text = gameManager.leftPoint.ToString();
    }

    private void LeftPlayerWin()
    {
        gameOverText.text = "Left Win";
    }

    private void RightPlayerWin()
    {
        gameOverText.text = "Right Win";
    }
}
