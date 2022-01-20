
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FourPlayerNumberContainer: PlayerNumberContainer
{
    public override void GeneratePlayerPositions()
    {
        team1Positions = new List<Vector2>
        {
            new Vector2(-3.5f, 0f), new Vector2(-7f, 2.5f), new Vector2(-7f, -2.5f),
            new Vector2(-9.5f, 0f)
        };

        team2Positions = new List<Vector2>
        {
            new Vector2(3.5f, 0f), new Vector2(7f, 2.5f), new Vector2(7f, -2.5f),
            new Vector2(9.5f, 0f)
        };
    }
}