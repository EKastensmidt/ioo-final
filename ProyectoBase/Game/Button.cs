using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        #region • Private fields/variables (9)
        private float posX;
        private float posY;
        private float scaleX;
        private float scaleY;
        private Button buttonUp;
        private Button buttonDown;
        private string texture;
        private float timer = 0f;
        private float timeToPress = 0.25f;
        #endregion

        #region • Public fields/variables (2)
        public float PosY { get => posY; set => posY = value; }
        public float PosX { get => posX; set => posX = value; }
        #endregion

        public Button(float posX, float posY, string texture, float escalaX, float escalaY)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.texture = texture;
            this.scaleX = escalaX;
            this.scaleY = escalaY;
        }

        public void Buttons(Button up, Button down)
        {
            buttonUp = up;
            buttonDown = down;
        }

        public Button Update()
        {
            timer += Program.DeltaTime;

            if (Engine.GetKey(Keys.W) && timer >= timeToPress)
            {
                timer = 0f;
                return GetUp();
            }
            else if (Engine.GetKey(Keys.S) && timer >= timeToPress)
            {
                timer = 0f;
                return GetDown();
            }
            else return this;
        }

        public void Render()
        {
            Engine.Draw(texture, PosX, PosY, scaleX, scaleY);
        }

        public Button GetUp()
        {
            if (buttonUp != null)
            {
                return buttonUp;
            }
            else return this;
        }

        public Button GetDown()
        {
            if (buttonDown != null)
            {
                return buttonDown;
            }
            else return this;
        }
    }
}
