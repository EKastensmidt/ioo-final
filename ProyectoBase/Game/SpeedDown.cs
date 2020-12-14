using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SpeedDown: Entity,IConsumable
    {
        public float Speed { get; set; }

        public SpeedDown(Vector2 position, float speed, float angle, float scale) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(34, 33, "Textures/Consumables/SpeedDown", "SPEEDDOWN"), new Collider())
        {
            this.Speed = speed;
        }

        public override void Update()
        {
            FuelMovement();
            if (Transform.Position.Y > 1000)
            {
                Destroy();
            }

        }
        public override void onCollision(Entity e)
        {

        }
        public void FuelMovement()
        {
            Transform.Position.Y += Speed * Program.DeltaTime;
        }
        public void Use()
        {
            Player.SpeedBuff /= 1.5f;

            Destroy();
        }
    }
}
