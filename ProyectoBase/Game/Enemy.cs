using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {
        private float angle;
        private float scale;
        private float speed;
        private bool isAlive;
        private int currentLife;

        public Vector2 position { get; set; } = Vector2.Zero;

        public Enemy(Vector2 initialPosition, float scale, float angle, float speed, int maxLife)
        {
            position = initialPosition;

            isAlive = true;
            currentLife = maxLife;
            //this.lifeController = new LifeController(maxLife);
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;
        }

  

        public void Update()
        {
            if (isAlive)
            {
                //CheckCollisions(GameManager.Instance.LevelController.Bullets);
                EnemyMovement();
                if (position.Y > 800)
                {
                    //GameManager.Instance.OnLoseHandler();
                }
            }
            else
            {
            }

        }

        private void EnemyMovement()
        {
            position += new Vector2(0, speed * Program.DeltaTime);
        }

        //private void CheckCollisions(List<Bullet> bullets)
        //{
        //    for (int i = bullets.Count - 1; i >= 0; i--)
        //    {
        //        if (IsBoxColliding(bullets[i]))
        //        {
        //            CollisionWithBullet(bullets[i]);
        //        }
        //    }
        //}

        private void CollisionWithBullet(Bullet bullet)
        {
            currentLife -= bullet.Damage;
            bullet.DestroyBullet();

            if (currentLife <= 0)
            {
                isAlive = false;
            }
        }

        //private bool IsBoxColliding(Bullet bullet)
        //{
        //    float distanceX = Math.Abs(position.X - bullet.Position.X);
        //    float distanceY = Math.Abs(position.Y - bullet.Position.Y);

        //    float sumHalfWidth = width / 2 + bullet.Width / 2;
        //    float sumHalfHeight = height / 2 + bullet.Height / 2;

        //    return distanceX <= sumHalfWidth && distanceY <= sumHalfHeight;
        //    return false;
        //}

        public void Render()
        {
            
        }
    }
}
