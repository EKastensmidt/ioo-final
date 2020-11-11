using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        #region • Private fields and variables (5)
        private Animation backgroundAnimation;
        private Animation currentAnimation;
        private static float elapsedTime = 0.0f;
        private static float enemySpawnRate = 1.5f;
        private static int ind = 0;
        private int enemyCounter = 29;
        #endregion

        #region • Public fields and variables (3)
        public Player Player { get; private set; }
        public List<Bullet> Bullets { get; private set; } = new List<Bullet>();
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();

        public float width => currentAnimation.CurrentFrame.Width;
        public float height => currentAnimation.CurrentFrame.Height;
        #endregion

        public LevelController()
        {
            Initialization();
            PlayBackgroundAnimation();
            currentAnimation = backgroundAnimation;

        }

        public void Initialization()
        {
            Player = new Player(new Vector2(400, 750), 1f, 0f, 300, 100);
        }

        public void Update()
        {
            Player.InputDetection();

            if (Player != null)
            {
                Player.Update();
            }
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Update();
            }
            EnemySpawner();
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].Update();
            }
            if (ind == enemyCounter)
            {
                //GameManager.Instance.OnWinHandler();
            }

            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame);

            if (Player != null)
            {
                Player.Render();
            }
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Render();
            }
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].Render();
            }
        }

        private void EnemySpawner()
        {
            Random _random = new Random();
            float num = _random.Next(25, 775);
            float x = num;
            float y = -200;
            elapsedTime += Program.DeltaTime;
            if (ind < 30 && elapsedTime > enemySpawnRate)
            {
                elapsedTime = 0;
                Enemy enemy = new Enemy(new Vector2(x, y), 1f, 0f, 175f, 100);
                Enemies.Add(enemy);
                Engine.Debug(ind);
                ind++;
            }
        }

        public void PlayBackgroundAnimation()
        {
            // Idle textures
            List<Texture> backgroundTexture = new List<Texture>();

            for (int i = 0; i < 52; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Background/{i}.png");
                backgroundTexture.Add(frame);
            }

            backgroundAnimation = new Animation(backgroundTexture, 0.04f, true, "Idle");
        }
    }
}
