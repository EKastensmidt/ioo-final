using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IEnemy
    {
        float Speed { get; set; }
        void Update();
        void Render();
        void EnemyMovement();
    }
}
