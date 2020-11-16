using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Fuel: Entity,IConsumable
    {
        public float Speed { get; set; }
        private float maxFuel = 100;

        public Fuel(Vector2 position, float speed, float angle, float scale,float maxFuel) :
            base(new Transform(position, angle, new Vector2(scale, scale)), new Renderer(32, 32, "Textures/Fuel", "FUEL"), new Collider())
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
            Player.Fuel = Player.Fuel + 25;
            if(Player.Fuel> maxFuel)
            {
                Player.Fuel = maxFuel;
            }
            Destroy();
        }
    }
}
