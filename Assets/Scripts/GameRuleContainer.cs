using UnityEngine;


public class GameRuleContainer : MonoBehaviour
{
    public PlayerNumberContainer playerNumberContainer;
    public GameWinRule gameWinRule;
    public PieceController team1Piece;
    public PieceController team2Piece;
        
    #region Singleton

    private static GameRuleContainer instance;

    public static GameRuleContainer Instance
    {
        get => instance;
        set => instance = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

}