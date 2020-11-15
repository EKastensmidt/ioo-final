using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Entity
    {
        private Transform transform;
        private Renderer renderer;
        private Collider collider;

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Collider Collider { get => collider; set => collider = value; }

        public void Render()
        {
            this.Renderer.Draw(this.Transform);
        }
        public event OnUpdate() 
        {

        }

        
        public void CheckCollisions(List<Entity> entities) 
        {
            foreach (Entity e in entities)
            {
                if(collider.IsColliding(this, e))
                {
                    //this.onCollision(e);
                    //e.onCollision(this);
                }
            }

            Update += CheckCollisions
        }
    }
}
