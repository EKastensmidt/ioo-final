using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Credits
    {
        public const string backgroundTexture = "Textures/Background/STREET0";
        public const string creditsTexture = "Textures/Scenes/Credits/Credits.png";
        public const string escapeTexture = "Textures/Escape.png";

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
