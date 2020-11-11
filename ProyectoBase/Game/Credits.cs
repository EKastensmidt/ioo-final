using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Credits
    {
        #region • String references (3)
        public const string backgroundTexture = "Textures/Background.png";
        public const string creditsTexture = "Textures/Screens/Credits.png";
        public const string escapeTexture = "Textures/Escape.png";
        #endregion

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeGameState(GameState.MainMenu);
            }
        }

        public void Render()
        {
            Engine.Draw(backgroundTexture);
            Engine.Draw(creditsTexture, 75, 100);
            Engine.Draw(escapeTexture, 50, 700, 0.5f, 0.5f);
        }
    }
}
