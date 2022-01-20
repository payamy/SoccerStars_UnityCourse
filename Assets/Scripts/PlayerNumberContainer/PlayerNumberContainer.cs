using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PlayerNumberContainer
{
    public List<Vector2> team1Positions;
    public List<Vector2> team2Positions;
    public abstract void GeneratePlayerPositions();
}