using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace Game
{
    public class Player
    {
        #region • Private fields/variables (11)
        private float speed;
        private int verticalMovement;
        private int horizontalMovement;
        private bool isShootingKeyPressed;
        private float currentShootingCooldown;
        private float shootingCooldown = 0.5f;
        //private LifeController lifeController;
        #endregion

        private Renderer renderer;
        private Transform transform;

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Player(Vector2 position, float scale, float angle, float speed, int maxLife)
        {
            Position = position;
            //this.lifeController = new LifeController(maxLife);
            this.speed = speed;

            this.transform = new Transform(position, angle, new Vector2(scale, scale));

            this.renderer = new Renderer(64, 64, "Textures/Test", "DOWN");
            this.renderer.addAnimation("DOWN", new Animation(true, 100, 4, 0));
            this.renderer.addAnimation("LEFT", new Animation(true, 100, 4, 1));
            this.renderer.addAnimation("RIGHT", new Animation(true, 100, 4, 2));
            this.renderer.addAnimation("UP", new Animation(true, 100, 4, 3));
        }

        public void Update()
        {
            currentShootingCooldown -= Program.DeltaTime;
            float multiplier = 1;
            if(horizontalMovement != 0 && verticalMovement != 0)
            {
                multiplier = 0.70710678118f;
            }
            this.transform.Position.X += horizontalMovement * multiplier * speed * Program.DeltaTime;
            this.transform.Position.Y += verticalMovement * multiplier * speed * Program.DeltaTime;

            if (isShootingKeyPressed && currentShootingCooldown <= 0)
            {
                ShootBullet();
                PlayShootSound();
            }
        }

        public void Render()
        {
            this.renderer.Draw(this.transform);
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

            this.renderer.State = state;

            //isShootingKeyPressed = Engine.GetKey(Keys.SPACE);
        }

        private void ShootBullet()
        {
            currentShootingCooldown = shootingCooldown;
            Bullet bullet = new Bullet(Position, 0.75f, 0f, 500f, 50);
        }

        private static void PlayShootSound()
        {
            SoundPlayer shootSound = new SoundPlayer("Audio/ShootSound.wav");
            shootSound.Play();
        }
    }
}
