using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SlowEnemy : Entity, IEnemy
    {
        public float Speed { get; set; }

        public SlowEnemy(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(82, 84, "Textures/Enemies/SlowEnemy", "SLOW"), new Collider())
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
