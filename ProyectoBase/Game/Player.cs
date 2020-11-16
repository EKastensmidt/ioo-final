using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace Game
{
    public class Player : Entity
    {
        private float speed;
        private int verticalMovement;
        private int horizontalMovement;


        public Player(Vector2 position, float scale, float angle, float speed) : 
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(64, 64, "Textures/Test", "DOWN"), new Collider())
        {
            this.speed = speed;

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
            Transform.Position.X += horizontalMovement * multiplier * speed * Program.DeltaTime;
            Transform.Position.Y += verticalMovement * multiplier * speed * Program.DeltaTime;
        }

        public override void onCollision(Entity e)
        {
            if(e is IEnemy)
            {
                Engine.Debug("muertoooo"+Program.DeltaTime);
                //GameManager.Instance.ChangeGameState(GameState.LoseScreen);
            }
            if (e is ICollectable)
            {
                ((ICollectable)e).PickUp();
            }
            if (e is IConsumable)
            {
                Engine.Debug("fuel");
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

            Renderer.State = state;
        }
    }
}
