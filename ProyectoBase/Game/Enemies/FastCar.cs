using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class FastCar: Entity,IEnemy
    {
        public float Speed { get; set; }

        public FastCar(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(40, 100, "Textures/FastCar", "FAST"), new Collider())
        {
            this.Speed = speed;
        }

        public override void Update()
        {
            EnemyMovement();
        }
        public override void onCollision(Entity e)
        {

        }
        public void EnemyMovement()
        {
            Transform.Position.Y += Speed * Program.DeltaTime;
        }
    }
}
