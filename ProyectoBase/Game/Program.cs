using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Program
    {
        private static float deltaTime;
        private static DateTime startTime;
        private static float lastFrameTime;

        public static float DeltaTime { get => deltaTime; }

        static void Main(string[] args)
        {
            Initialization();
            while (true)
            {
                UpdateTime();
                Update();
                Render();
            }
        }
        private static void Initialization()
        {
            startTime = DateTime.Now;
            Engine.Initialize("Jueguito", 800, 800,true);
            GameManager.Instance.Initialization();
        }

        private static void Update()
        {
            GameManager.Instance.Update();
        }
        private static void Render()
        {
            Engine.Clear();
            GameManager.Instance.Render();

            Engine.Show();
        }
        private static void UpdateTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}
