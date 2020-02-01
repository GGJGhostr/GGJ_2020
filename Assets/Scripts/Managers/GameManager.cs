using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghostr
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;
        public static GameManager Instance
        {
            get
            {
                if (!instance)
                    instance = new GameManager();
                return instance;
            }
        }

        public PlayerManager PlayerManager { get; private set; }
        public ScoringManager ScoringManager { get; private set; }
        public GameDataManager GameDataManager { get; private set; }
        public SceneHandler SceneHandler { get; private set; }


        private void Awake()
        {
            if (FindObjectsOfType<GameManager>().Length > 1)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        private void Start()
        {
            CreateManager();
            SceneHandler.ChangeScene("MainScreen");
        }

        public void StartGame()
        {
            SceneHandler.ChangeScene("MainGame");
            PlayerManager.RegisterCharacterReference();
        }

        private void CreateManager()
        {
            GameObject manager_gao = new GameObject("Managers object");
            SceneHandler = manager_gao.AddComponent<SceneHandler>();
            PlayerManager = manager_gao.AddComponent<PlayerManager>();
            GameDataManager = manager_gao.AddComponent<GameDataManager>();
            ScoringManager = manager_gao.AddComponent<ScoringManager>();
        }

        public void OnWin(Character winner)
        {
            PlayerManager.ClearPlayer();
            SceneHandler.ChangeScene("MainScreen");
         
            // TODO:
            // Display Win Screen
            // Clear player at the end of the WinScreen
        }


    }
}