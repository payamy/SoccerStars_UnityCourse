using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public abstract class PlayerNumberContainer
{
    public GameObject team1Piece;
    public GameObject team2Piece;
    protected List<Vector2> team1Positions;
    protected List<Vector2> team2Positions;
    public abstract void GeneratePlayers();
}