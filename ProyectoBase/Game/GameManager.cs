using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum GameState
    {
        MainMenu,
        Credits,
        WinScreen,
        LoseScreen,
        Level,
    }
    public class GameManager
    {
        public MainMenu MainMenu { get; private set; }
        public Credits Credits { get; private set; }
        public LevelController LevelController { get; private set; }
        public WinScreen WinScreen { get; private set; }
        public LoseScreen LoseScreen { get; private set; }

        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public GameState CurrentState { get; private set; }

        public void Initialization()
        {
            LevelController = new LevelController();
            LoseScreen = new LoseScreen();
            WinScreen = new WinScreen();
            MainMenu = new MainMenu();
            Credits = new Credits();
            ChangeGameState(GameState.MainMenu);
            //WinScreen.OnWin += OnWinHandler;
            //LoseScreen.OnLose += OnLoseHandler;
        }

        public void Update()
        {
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    MainMenu.Update();
                    break;
                case GameState.Credits:
                    Credits.Update();
                    break;
                case GameState.Level:
                    LevelController.Update();
                    break;
                case GameState.WinScreen:
                    WinScreen.Update();
                    break;
                case GameState.LoseScreen:
                    LoseScreen.Update();
                    break;
                default:
                    break;
            }
        }
        public void Render()
        {
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    MainMenu.Render();
                    break;
                case GameState.Credits:
                    Credits.Render();
                    break;
                case GameState.WinScreen:
                    WinScreen.Render();
                    break;
                case GameState.LoseScreen:
                    LoseScreen.Render();
                    break;
                case GameState.Level:
                    LevelController.Render();
                    break;
                default:
                    break;
            }
        }
        public void ChangeGameState(GameState gameState)
        {
            CurrentState = gameState;
        }
        //public void OnWinHandler()
        //{
        //    GameManager.Instance.ChangeGameState(GameState.WinScreen);
        //}
        //public void OnLoseHandler()
        //{
        //    GameManager.Instance.ChangeGameState(GameState.LoseScreen);
        //}
    }
}
