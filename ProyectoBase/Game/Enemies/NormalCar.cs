using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NormalCar : Entity ,IEnemy
    {
        public float Speed { get ; set; }

        public NormalCar(Vector2 position,float speed,float angle,float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(40, 100, "Textures/NormalCar", "BASIC"), new Collider())
        {
            this.Speed = speed;
        }

        public override void Update()
        {
            EnemyMovement();
            if(Transform.Position.Y > 1000)
            {
                Destroy();
            }
        }
        public override void onCollision(Entity e)
        {
         
        }
        public void EnemyMovement()
        {
            Transform.Position.Y += Speed*Program.DeltaTime;
        }
        
    }
}
