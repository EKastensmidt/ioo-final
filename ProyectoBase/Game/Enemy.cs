using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {
        #region • Private variables/fields (9)
        private float angle;
        private float scale;
        private float speed;
        private bool isAlive;
        private int currentLife;

        // References
        private LifeController lifeController;
        private Animation idleAnimation;
        private Animation explosionAnimation;
        private Animation currentAnimation;
        #endregion

        #region • Public variables/fields (3)
        public float width => currentAnimation.CurrentFrame.Width;
        public float height => currentAnimation.CurrentFrame.Height;
        public Vector2 position { get; set; } = Vector2.Zero;
        #endregion

        public Enemy(Vector2 initialPosition, float scale, float angle, float speed, int maxLife)
        {
            position = initialPosition;

            isAlive = true;
            currentLife = maxLife;
            this.lifeController = new LifeController(maxLife);
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;

            PlayEnemyAnimations();
            currentAnimation = idleAnimation;
        }

        private void PlayEnemyAnimations()
        {
            // Idle textures
            List<Texture> idleTextures = new List<Texture>();

            for (int i = 0; i < 3; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Enemy/Idle/{i}.png");
                idleTextures.Add(frame);
            }

            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");

            // Explosion textures
            List<Texture> explosionTextures = new List<Texture>();
            for (int i = 0; i < 7; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Enemy/Explosion/{i}.png");
                explosionTextures.Add(frame);
            }

            explosionAnimation = new Animation(explosionTextures, 0.05f, false, "Explosion");

        }

        public void Update()
        {
            if (isAlive)
            {
                CheckCollisions(GameManager.Instance.LevelController.Bullets);
                EnemyMovement();
                if (position.Y > 800)
                {
                    //GameManager.Instance.OnLoseHandler();
                }
            }
            else
            {
                if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
                {
                    GameManager.Instance.LevelController.Enemies.Remove(this);
                }
            }

            currentAnimation.Update();
        }

        private void EnemyMovement()
        {
            position += new Vector2(0, speed * Program.DeltaTime);
        }

        private void CheckCollisions(List<Bullet> bullets)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (IsBoxColliding(bullets[i]))
                {
                    CollisionWithBullet(bullets[i]);
                }
            }
        }

        private void CollisionWithBullet(Bullet bullet)
        {
            currentLife -= bullet.Damage;
            bullet.DestroyBullet();

            if (currentLife <= 0)
            {
                isAlive = false;
                currentAnimation = explosionAnimation;
            }
        }

        private bool IsBoxColliding(Bullet bullet)
        {
            float distanceX = Math.Abs(position.X - bullet.Position.X);
            float distanceY = Math.Abs(position.Y - bullet.Position.Y);

            float sumHalfWidth = width / 2 + bullet.Width / 2;
            float sumHalfHeight = height / 2 + bullet.Height / 2;

            return distanceX <= sumHalfWidth && distanceY <= sumHalfHeight;
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, position.X, position.Y, scale, scale, angle, GetOffsetX(), GetOffsetY());
        }

        #region • Get Offsets (X, Y Axis)
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
