using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu
    {
        private Arrow arrow;
        private Button startGameButton;
        private Button creditsButton;
        private Button quitButton;
        private Button currentButton;
        private List<Button> buttons = new List<Button>();

        public const string backgroundTexture = "Textures/Background/STREET0";
        //public const string titleTexture = "Textures/Title.png";
        public const string startButtonTexture = "Textures/Scenes/Menu/start.png";
        public const string creditsButtonTexture = "Textures/Scenes/Menu/credits.png";
        public const string quitButtonTexture = "Textures/Scenes/Menu/quit.png";

        public MainMenu()
        {
            // Start button
            startGameButton = new Button(250f, 300f, startButtonTexture, 1f, 1f);
            buttons.Add(startGameButton);

            // Credits button
            creditsButton = new Button(225f, 450f, creditsButtonTexture, 1f, 1f);
            buttons.Add(creditsButton);

            // Quit button
            quitButton = new Button(250f, 600f, quitButtonTexture, 1f, 1f);
            buttons.Add(quitButton);

            startGameButton.Buttons(null, creditsButton);
            creditsButton.Buttons(startGameButton, quitButton);
            quitButton.Buttons(creditsButton, null);

            // Arrow indicator
            currentButton = startGameButton;
            arrow = new Arrow();
            arrow.Update(currentButton.PosX, currentButton.PosY);
        }
        public void Update()
        {
            currentButton = currentButton.Update();
            arrow.Update(currentButton.PosX, currentButton.PosY);

            if (Engine.GetKey(Keys.SPACE))
            {
                EnterButton();
            }
        }
        public void Render()
        {
            Engine.Draw(backgroundTexture);
            //Engine.Draw(titleTexture, 75, 50, 1f, 1f);

            foreach (var button in buttons)
            {
                button.Render();
            }
            arrow.Render();
        }
        private void EnterButton()
        {
            if (currentButton == startGameButton)
            {
                GameManager.Instance.ChangeGameState(GameState.Level);
            }

            else if (currentButton == creditsButton)
            {
                GameManager.Instance.ChangeGameState(GameState.Credits);
            }

            else if (currentButton == quitButton)
            {
                Environment.Exit(1);
            }
        }
    }
}

