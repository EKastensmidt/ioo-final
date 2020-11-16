using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Coin : Entity, ICollectable
    {
        public float Speed { get; set; }
        public static int coin { get; set; }

        public Coin(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(32, 32, "Textures/Coin", "COIN"), new Collider())
        {
            this.Speed = speed;
            Renderer.addAnimation("COIN", new Animation(true, 100, 4, 0));
        }

        public override void Update()
        {
            CoinMovement();
            if (Transform.Position.Y > 1000)
            {
                Destroy();
            }

        }
        public void PickUp()
        {
            coin++;
            Engine.Debug("coin:"+coin);
            Destroy();
        }
        public override void onCollision(Entity e)
        {

        }
        public void CoinMovement()
        {
            Transform.Position.Y += Speed * Program.DeltaTime;
        }

    }
}
