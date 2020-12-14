using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LoseScreen
    {
        public const string backgroundTexture = "Textures/Background/SPACE0";
        public const string escapeTexture = "Textures/Escape.png";
        public const string gameOverTexture = "Textures/Scenes/LoseScreen/gameOver.png";

        //public LoseCondition OnLose;

        public LoseScreen()
        {

        }

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeGameState(GameState.MainMenu);
            }
        }

        public void Render()
        {
            Engine.Debug("TotalCoins:" + Coin.coin);
            Engine.Draw(backgroundTexture);
            Engine.Draw(escapeTexture, 50, 700, 0.5f, 0.5f);
            Engine.Draw(gameOverTexture, 150, 250);
        }
    }
}
