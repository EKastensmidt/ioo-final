using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        #region • Private fields/variables (9)
        private float angle;
        private float scale;
        private float speed;
        private float collisionRadius;
        private float lifeTime = 8f;
        private float currentLifeTime;
        private int damage;

        private Animation idleAnimation;
        private Animation currentAnimation;
        #endregion

        #region • Public fields/variables (5)
        public float CollisionRadius => collisionRadius;
        public int Damage => damage;
        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Width => currentAnimation.CurrentFrame.Width;
        public float Height => currentAnimation.CurrentFrame.Height;
        #endregion

        public Bullet(Vector2 initialPosition, float scale, float angle, float speed, int damage)
        {
            Position = initialPosition;

            this.damage = damage;
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;

            GameManager.Instance.LevelController.Bullets.Add(this);
            PlayBulletAnimation();
            currentAnimation = idleAnimation;
            collisionRadius = Height > Width ? Height / 2 : Width / 2;
        }

        public void Update()
        {
            currentLifeTime += Program.DeltaTime;

            if (currentLifeTime >= lifeTime)
            {
                DestroyBullet();
            }

            Position = new Vector2(Position.X, Position.Y - speed * Program.DeltaTime);

            currentAnimation.Update();
        }

        public void DestroyBullet()
        {
            GameManager.Instance.LevelController.Bullets.Remove(this);
        }

        private void PlayBulletAnimation()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 1; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Bullet/idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, Position.X, Position.Y, scale, scale, angle, GetOffsetX(), GetOffsetY());
        }

        #region • Get Offsets (X, Y)
        private float GetOffsetX()
        {
            return (currentAnimation.CurrentFrame.Width * scale) / 2f;
        }

        private float GetOffsetY()
        {
            return (currentAnimation.CurrentFrame.Height * scale) / 2f;
        }
        #endregion
    }
}

