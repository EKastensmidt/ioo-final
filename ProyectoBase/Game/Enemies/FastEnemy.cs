using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class FastEnemy : Entity, IEnemy
    {
        public float Speed { get; set; }

        public FastEnemy(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(104, 84, "Textures/Enemies/FastEnemy", "FAST"), new Collider())
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
