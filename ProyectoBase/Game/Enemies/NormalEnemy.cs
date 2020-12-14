using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NormalEnemy : Entity, IEnemy
    {
        public float Speed { get; set; }

        public NormalEnemy(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(93, 84, "Textures/Enemies/Normal", "NORMAL"), new Collider())
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
