using System;
using DefaultNamespace;

[Serializable]
public class TimeWinRule : GameWinRule
{
    public override bool HaveWonGame()
    {
        return false;
    }
}