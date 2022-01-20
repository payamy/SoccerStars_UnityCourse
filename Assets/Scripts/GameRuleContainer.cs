using UnityEngine;

namespace DefaultNamespace
{
    public class GameRuleContainer : MonoBehaviour
    {
        
        
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
}