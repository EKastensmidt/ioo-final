﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        private static float elapsedTime = 0.0f;
        private static float enemySpawnRate = 1f;
        private static float enemySpawnRateMultiplier = 0.000001f;
        private static float coinSpawnRate = 4f;
        private static float coinElapsedTime = 0.0f;
        private static float fuelSpawnRate = 5f;
        private static float fuelElapsedTime = 0.0f;
        private Pool<Entity> enemies;
        private Pool<Entity> coins;
        private Pool<Entity> fuels;

        public Player Player { get; private set; }

        public LevelController()
        {
            Initialization();
            //PlayBackgroundAnimation();
            //currentAnimation = backgroundAnimation;
        }

        public void Initialization()
        {
            Player = new Player(new Vector2(400, 700), 1f, 0f, 300);
            enemies = new Pool<Entity>();
            coins = new Pool<Entity>();
            fuels = new Pool<Entity>();
        }

        public void Update()
        {
            Player.Update();
            enemies.Update();
            coins.Update();
            fuels.Update();
            Player.CheckCollisions(enemies.Used);
            Player.CheckCollisions(coins.Used);
            Player.CheckCollisions(fuels.Used);

            UpdateDifficulty();

            CoinSpawner();
            FuelSpawner();
            EnemySpawner();
        }

        public void Render()
        {
            Engine.Draw("Textures/Background/SPACE0");
            Player.Render();
            enemies.Render();
            coins.Render();
            fuels.Render();
        }
        private Random random;
        private Random GetRandom()
        {
            if (random == null)
            {
                random = new Random();
            }
            return random;
        }
        private void EnemySpawner()
        {
            elapsedTime += Program.DeltaTime;
            if (elapsedTime > enemySpawnRate)
            {
                float x = GetRandom().Next(25, 775);
                float y = -200;
                elapsedTime = 0;
                Entity enemy = enemies.Get();
                if(enemy == null)
                {
                    enemy = EnemyFactory.Spawn(RandomEnumValue<EnemyFactory.Enemies>());
                    enemies.Add(enemy);
                }
                enemy.Transform.Position = new Vector2(x, y);
            }
        }

        private void CoinSpawner()
        {
            coinElapsedTime += Program.DeltaTime;
            if (coinElapsedTime > coinSpawnRate)
            {
                float x = GetRandom().Next(25, 775);
                float y = -200;
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
            fuelElapsedTime += Program.DeltaTime;
            if (fuelElapsedTime > fuelSpawnRate)
            {
                float x = GetRandom().Next(25, 775);
                float y = -200;
                fuelElapsedTime = 0;
                Entity fuel = fuels.Get();
                if (fuel == null)
                {
                    fuel = ConsumableFactory.Spawn(RandomEnumValue<ConsumableFactory.Consumables>());
                    fuels.Add(fuel);
                }
                fuel.Transform.Position = new Vector2(x, y);
            }
        }
        private void UpdateDifficulty()
        {
            enemySpawnRate = enemySpawnRate - enemySpawnRateMultiplier * Program.DeltaTime;
        }
        public T RandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            int random = GetRandom().Next(0, values.Length);
            return (T)values.GetValue(random);
        }
    }
}
