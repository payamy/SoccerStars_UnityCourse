using System;

namespace DefaultNamespace
{
    [Serializable]
    public abstract class GameWinRule
    {
        public abstract bool HaveWonGame();
    }
}