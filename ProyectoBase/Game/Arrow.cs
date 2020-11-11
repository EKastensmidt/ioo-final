using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Arrow
    {
        #region • Public fields/variables (3)
        private float posX;
        private float posY;
        private float offset = 120f;
        #endregion

        public void Update(float x, float y)
        {
            posX = x - offset;
            posY = y;
        }

        public void Render()
        {
            Engine.Draw("Textures/Buttons/ArrowIndicator.png", posX, posY, 1f, 1f, 0, 0, 0);
        }
    }
}
