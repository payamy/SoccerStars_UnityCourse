using System;


[Serializable]
public abstract class GameWinRule
{
    public abstract WinStatus CheckWin();
}
