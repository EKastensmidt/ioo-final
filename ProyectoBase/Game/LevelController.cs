using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        private static float elapsedTime = 0.0f;
        private static float enemySpawnRate = 1.5f;
        private static float coinSpawnRate = 6f;
        private static float coinElapsedTime = 0.0f;
        private static float fuelSpawnRate = 11f;
        private static float fuelElapsedTime = 0.0f;
        private Pool enemies;
        private Pool coins;
        private Pool fuel;

        public Player Player { get; private set; }

        public LevelController()
        {
            Initialization();
            //PlayBackgroundAnimation();
            //currentAnimation = backgroundAnimation;

        }

        public void Initialization()
        {
            Player = new Player(new Vector2(0, 0), 1f, 0f, 300);
            enemies = new Pool();
            coins = new Pool();
            fuel = new Pool();
        }

        public void Update()
        {
            Player.Update();
            enemies.Update();
            coins.Update();
            fuel.Update();
            Player.CheckCollisions(enemies.Used);
            Player.CheckCollisions(coins.Used);
            Player.CheckCollisions(fuel.Used);

            CoinSpawner();
            FuelSpawner();
            EnemySpawner();
        }

        public void Render()
        {
            Player.Render();
            enemies.Render();
            coins.Render();
            fuel.Render();
        }

        private void EnemySpawner()
        {
            Random _random = new Random();
            float num = _random.Next(25, 775);
            float x = num;
            float y = -200;
            elapsedTime += Program.DeltaTime;
            if (elapsedTime > enemySpawnRate)
            {
                elapsedTime = 0;
                Entity enemy = enemies.Get();
                if(enemy == null)
                {
                    enemy = Factory.Spawn();
                    Engine.Debug("New Car");
                    enemies.Add(enemy);
                } 
                enemy.Transform.Position = new Vector2(x, y);
            }
        }

        private void CoinSpawner()
        {
            Random _random = new Random();
            float num = _random.Next(25, 775);
            float x = num;
            float y = -200;
            coinElapsedTime += Program.DeltaTime;
            if (coinElapsedTime > coinSpawnRate)
            {
                coinElapsedTime = 0;
                Entity coin = coins.Get();
                if (coin == null)
                {
                    coin = new Coin(new Vector2(x, y), 100, 0, 1);
                    coins.Add(coin);
                }
                coin.Transform.Position = new Vector2(x, y);
            }
        }
        private void FuelSpawner()
        {
            Random _random = new Random();
            float num = _random.Next(25, 775);
            float x = num;
            float y = -200;
            fuelElapsedTime += Program.DeltaTime;
            if (fuelElapsedTime > fuelSpawnRate)
            {
                fuelElapsedTime = 0;
                Entity fuel = coins.Get();
                if (fuel == null)
                {
                    fuel = new Fuel(new Vector2(x, y), 100, 0, 1);
                    coins.Add(fuel);
                }
                fuel.Transform.Position = new Vector2(x, y);
            }
        }
    }
}
