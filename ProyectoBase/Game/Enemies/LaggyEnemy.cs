using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LaggyEnemy : Entity, IEnemy
    {
        private float stopCD = 1.25f;
        private float stopTimer = 0f;
        private float waitCD = 3;
        private float waitTimer = 0f;

        public float Speed { get; set; }

        public LaggyEnemy(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(97, 84, "Textures/Enemies/LaggyEnemy", "LAGGY"), new Collider())
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
            stopTimer += Program.DeltaTime;
            if (stopCD > stopTimer)
            {
                Transform.Position.Y += Speed * Program.DeltaTime;
                waitTimer = 0;
            }
            else if (stopCD < stopTimer)
            {
                waitTimer += Program.DeltaTime;
                if (waitCD < waitTimer)
                {
                    stopTimer = 0;
                }
            }
        }
    }
}
