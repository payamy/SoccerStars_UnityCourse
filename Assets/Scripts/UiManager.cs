using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text leftScoreText;
    public Text rightScoreText;
    public Text gameOverText;
    public Text timerText;
    public Text playerTurnText;
    public GameObject player1Win;
    public GameObject player2Win;
    public GameObject tieText;
    public GameObject returnToMenuButton;

    public EventSystemManager eventSystem;

    public GameManager gameManager;

    private void Update()
    {
        var timerMinutes = Mathf.Floor(GameManager.Instance.gameTime / 60f);
        var timerSecond = (int) GameManager.Instance.gameTime % 60f;
        timerText.text = timerMinutes.ToString("00") + ":" + timerSecond.ToString("00");
        playerTurnText.text = "Player " + (GameManager.Instance.turn + 1) + " turn";

    }

    void Start()
    {
        eventSystem.goalEvent.AddListener(UpdateScore);
        eventSystem.onLeftWin.AddListener(LeftPlayerWin);
        eventSystem.onRightWin.AddListener(RightPlayerWin);
        eventSystem.onTie.AddListener(Tie);
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
        player1Win.SetActive(true);
        returnToMenuButton.SetActive(true);
    }

    private void RightPlayerWin()
    {
        player2Win.SetActive(true);
        returnToMenuButton.SetActive(true);
    }

    private void Tie()
    {
        tieText.SetActive(true);
        returnToMenuButton.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
