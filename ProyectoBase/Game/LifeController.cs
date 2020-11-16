using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {
        #region • Private field/variables (2)
        private int currentLife;
        private int maxLife;
        #endregion

        public bool IsAlive => currentLife > 0;

        public int CurrentLife
        {
            get => currentLife;
            set
            {
                currentLife = value;
                if (!IsAlive)
                {
                    //Kill();
                }
                if (currentLife > maxLife)
                {
                    currentLife = maxLife;
                }
            }
        }

        public LifeController(int maxLife)
        {
            this.maxLife = maxLife;
            CurrentLife = maxLife;
        }

        public void GetDamage(int damage)
        {
            CurrentLife -= damage;
        }

        public void GetHeal(int heal)
        {
            CurrentLife += heal;
        }
    }
}
