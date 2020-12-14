using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BigEnemy : Entity, IEnemy
    {
        public float Speed { get; set; }

        public BigEnemy(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale*2, scale*2)), new Renderer(103*2, 84*2, "Textures/Enemies/BigEnemy", "BIG"), new Collider())
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
