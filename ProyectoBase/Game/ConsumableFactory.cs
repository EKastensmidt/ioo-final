using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ConsumableFactory
    {
        public enum Consumables { Fuel = 0, SpeedUp = 1, SpeedDown = 2, FuelDown = 3 }

        public static Entity Spawn(Consumables consumable)
        {

            switch (consumable)
            {
                case Consumables.Fuel:
                    return new Fuel(Vector2.Zero, 100, 0, 1, 100);
                case Consumables.SpeedUp:
                    return new SpeedUp(Vector2.Zero, 100, 0, 1);
                case Consumables.SpeedDown:
                    return new SpeedDown(Vector2.Zero, 100, 0, 1);
                case Consumables.FuelDown:
                    return new FuelDown(Vector2.Zero, 100, 0, 1,100);
            }
            return null;
        }
    }
}
