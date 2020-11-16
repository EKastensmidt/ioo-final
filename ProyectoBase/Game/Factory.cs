using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Factory
    {
        public static Entity Spawn()
        {
            Random _random = new Random();
            float num = _random.Next(10);
            switch (num)
            {
                case 1:
                    return new NormalCar(Vector2.Zero, 200, 0, 1);
                case 2:
                    return new Truck(Vector2.Zero, 75, 0, 1);
                default:
                    return new FastCar(Vector2.Zero, 500, 0, 1);
            }
                
        }

    }
}
