using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftPoint;
    public int rightPoint;

    public List<PieceController> player1PieceControllers;
    public List<PieceController> player2PieceControllers;
    public BallController ballController;
    public WinStatus winStatus = WinStatus.NoWin;
    public int turn;


    public int maxPoint;

    public EventSystemManager eventSystem;

    #region Singleton

    private static GameManager instance;
    public bool turnStarted;
    public bool gameFinished;
    public float gameTime;

    public static GameManager Instance
    {
        get => instance;
        set => instance = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion
    
    private void Start()
    {
        GameRuleContainer.Instance.playerNumberContainer.GeneratePlayerPositions();
        InstantiatePieces();
    }

    private void Update()
    {
        if (gameFinished) return;
        gameTime += Time.deltaTime;
        var  gameStatus = GameRuleContainer.Instance.gameWinRule.CheckWin();
        if (gameStatus != WinStatus.NoWin)
        {
            
            Destroy(ballController.rb);
            if (gameStatus == WinStatus.Player1)
            {
                eventSystem.onLeftWin.Invoke();
            }
            else if (gameStatus == WinStatus.Player2)
            {
                eventSystem.onRightWin.Invoke();
            }
            else
            {
                eventSystem.onTie.Invoke();
            }
        }
    }

    private void InstantiatePieces()
    {
        var playerNumberContainer = GameRuleContainer.Instance.playerNumberContainer;
        foreach (var piecePosition in playerNumberContainer.team1Positions)
        {
            var teamPiece = Instantiate(GameRuleContainer.Instance.team1Piece, piecePosition, Quaternion.identity);
            teamPiece.turn = true;
            player1PieceControllers.Add(teamPiece);
        }

        foreach (var piecePosition in playerNumberContainer.team2Positions)
        {
            var teamPiece = Instantiate(GameRuleContainer.Instance.team2Piece, piecePosition, Quaternion.identity);
            teamPiece.turn = false;
            player2PieceControllers.Add(teamPiece);
        }
    }
    public bool PiecesMoveEnded()
    {
        foreach (var player1Piece in player1PieceControllers)
        {
            if (player1Piece.rb.velocity != Vector2.zero) return false;
        }
        
        foreach (var player2Piece in player2PieceControllers)
        {
            if (player2Piece.rb.velocity != Vector2.zero) return false;
        }

        if (ballController.rb.velocity != Vector2.zero) return false;
        return true;
    }

    public void ChangeTurn()
    {
        turn = (turn + 1) % 2;
        foreach (var player1Piece in player1PieceControllers)
        {
            player1Piece.turn = turn == 0;
        }

        foreach (var player2Piece in player2PieceControllers)
        {
            player2Piece.turn = turn == 1;
        }
        print("turn changed");
    }

    public void BallEnteredGoal(GoalSide goalSide)
    {
        if (goalSide == GoalSide.Left)
        {
            leftPoint++;
        }
        else
        {
            rightPoint++;
        }

        ballController.transform.position = Vector3.zero;
        ballController.rb.velocity = Vector3.zero;

        var i = 0;
        var playerNumberContainer = GameRuleContainer.Instance.playerNumberContainer;
        
        foreach (var piecePosition in playerNumberContainer.team1Positions)
        {
            player1PieceControllers[i].transform.position = piecePosition;
            player1PieceControllers[i].rb.velocity = Vector2.zero;
            i++;
        }

        i = 0;
        foreach (var piecePosition in playerNumberContainer.team2Positions)
        {
            player2PieceControllers[i].transform.position = piecePosition;
            player2PieceControllers[i].rb.velocity = Vector2.zero;
            i++;
        }
    }
}
