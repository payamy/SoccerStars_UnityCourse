using System;
using DefaultNamespace;

[Serializable]
public class TimeWinRule : GameWinRule
{
    private float time = 90f;

    public override WinStatus CheckWin()
    {
        if (GameManager.Instance.gameTime < time) return WinStatus.NoWin;

        if (GameManager.Instance.leftPoint > GameManager.Instance.rightPoint) return WinStatus.Player1;
        if (GameManager.Instance.rightPoint > GameManager.Instance.leftPoint) return WinStatus.Player2;
        return WinStatus.Tie;
    }
}