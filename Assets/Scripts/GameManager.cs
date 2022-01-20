using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftPoint;
    public int rightPoint;

    public List<PieceController> player1PieceControllers;
    public List<PieceController> player2PieceControllers;

    public int maxPoint;

    public EventSystemManager eventSystem;

    #region Singleton

    private static GameManager instance;

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
            player1PieceControllers.Add(teamPiece);
        }
    }

    private void Update()
    {
        if (leftPoint == maxPoint)
        {
            // call win event
            eventSystem.OnLeftWin.Invoke();

            // make ball fixed
            Destroy(FindObjectOfType<BallController>().GetComponent<Rigidbody2D>());
        }
        if (rightPoint == maxPoint)
        {
            // call lose event
            eventSystem.OnRightWin.Invoke();

            // make ball fixed
            Destroy(FindObjectOfType<BallController>().GetComponent<Rigidbody2D>());
        }
    }
}
