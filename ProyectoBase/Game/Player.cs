using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;


namespace Game
{
    public class Player : Entity
    {
        private static float fuel = 100;
        private float speed;
        private int verticalMovement;
        private int horizontalMovement;
        private int dashCD = 2;
        private float dashTime = 0f;
        private bool isDashing = false;
        private int dashDistance = 60;
        private static float speedBuff = 1f;

        public static float Fuel { get => fuel; set => fuel = value; }
        public float Speed { get => speed; set => speed = value; }
        public static float SpeedBuff { get => speedBuff; set => speedBuff = value; }

        public Player(Vector2 position, float scale, float angle, float speed) : 
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(64, 64, "Textures/Test", "DOWN"), new Collider())
        {
            this.Speed = speed;
            Renderer.addAnimation("DOWN", new Animation(true, 100, 4, 0));
            Renderer.addAnimation("LEFT", new Animation(true, 100, 4, 1));
            Renderer.addAnimation("RIGHT", new Animation(true, 100, 4, 2));
            Renderer.addAnimation("UP", new Animation(true, 100, 4, 3));
        }

        public override void Update()
        {
            InputDetection();
            float multiplier = 1;
            if(horizontalMovement != 0 && verticalMovement != 0)
            {
                multiplier = 0.70710678118f;
            }
            Transform.Position.X += horizontalMovement * multiplier * Speed * Program.DeltaTime * speedBuff;
            Transform.Position.Y += verticalMovement * multiplier * Speed * Program.DeltaTime * speedBuff;
            Engine.Debug("FUEL:" + fuel);
            FuelLoss();
        }

        public override void onCollision(Entity e)
        {
            if(e is IEnemy)
            {
                Thread.Sleep(1250);
                GameManager.Instance.ChangeGameState(GameState.LoseScreen);
            }
            if (e is ICollectable)
            {
                ((ICollectable)e).PickUp();
            }
            if (e is IConsumable)
            {
                ((IConsumable)e).Use();
            }
        }

        public void InputDetection()
        {
            verticalMovement = 0;
            horizontalMovement = 0;
            string state = "DOWN";
            if (Engine.GetKey(Keys.A))
            {
                horizontalMovement += -1;
                state = "LEFT";
            }
            if (Engine.GetKey(Keys.D))
            {
                horizontalMovement += 1;
                state = "RIGHT";
            }
            if (Engine.GetKey(Keys.W)) { 
                verticalMovement += -1;
                state = "UP";
            }
            if (Engine.GetKey(Keys.S)) { 
                verticalMovement += 1;
                state = "DOWN";
            }
            dashTime += Program.DeltaTime;
            if (Engine.GetKey(Keys.LSHIFT) && dashCD > dashTime && isDashing == false)
            {
                isDashing = true;
                if (verticalMovement != 0)
                {
                    verticalMovement *= dashDistance;
                }
                if (horizontalMovement != 0)
                {
                    horizontalMovement *= dashDistance;
                }
            }
            if (dashTime > dashCD)
            {
                isDashing = false;
                dashTime = 0;
            }
            Renderer.State = state;   
        }
        public void FuelLoss()
        {
            if (Fuel < 0)
            {
                GameManager.Instance.ChangeGameState(GameState.LoseScreen);
            }
            Fuel -= Program.DeltaTime / 0.5f;
        }
        
    }
}
