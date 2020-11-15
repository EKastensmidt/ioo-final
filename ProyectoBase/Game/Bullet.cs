using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        private float angle;
        private float scale;
        private float speed;
        private float collisionRadius;
        private float lifeTime = 8f;
        private float currentLifeTime;
        private int damage;

        public float CollisionRadius => collisionRadius;
        public int Damage => damage;
        public Vector2 Position { get; set; } = Vector2.Zero;

        public Bullet(Vector2 initialPosition, float scale, float angle, float speed, int damage)
        {
            Position = initialPosition;

            this.damage = damage;
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;

            GameManager.Instance.LevelController.Bullets.Add(this);
        }

        public void Update()
        {
            currentLifeTime += Program.DeltaTime;

            if (currentLifeTime >= lifeTime)
            {
                DestroyBullet();
            }

            Position = new Vector2(Position.X, Position.Y - speed * Program.DeltaTime);

        }

        public void DestroyBullet()
        {
            GameManager.Instance.LevelController.Bullets.Remove(this);
        }


        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, Position.X, Position.Y, scale, scale, angle, GetOffsetX(), GetOffsetY());
        }
    }
}

