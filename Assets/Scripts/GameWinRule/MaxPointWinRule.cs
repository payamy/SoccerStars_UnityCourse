using UnityEngine;


public class MaxPointWinRule: GameWinRule
{
    private int maxPoint = 5;
        
    public override WinStatus CheckWin()
    {
        if (GameManager.Instance.leftPoint == maxPoint)
            return WinStatus.Player1;
        if (GameManager.Instance.rightPoint == maxPoint)
            return WinStatus.Player2;

        return WinStatus.NoWin;
    }
}
