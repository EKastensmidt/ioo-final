using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class EnemyFactory
    {
        public enum Enemies {Normal = 0, Slow = 1, Fast = 2, Laggy = 3, Big = 4 }
        
        public static Entity Spawn (Enemies enemies)
        {
            switch (enemies)
            {
                case Enemies.Normal:
                    return new NormalEnemy(Vector2.Zero, 200, 0, 1);
                case Enemies.Slow:
                    return new SlowEnemy(Vector2.Zero, 75, 0, 1);
                case Enemies.Fast:
                    return new FastEnemy(Vector2.Zero, 500, 0, 1);
                case Enemies.Laggy:
                    return new LaggyEnemy(Vector2.Zero, 350, 0, 1);
                case Enemies.Big:
                    return new BigEnemy(Vector2.Zero, 125, 0, 1);
            }
            return null;
        }
    }
}
