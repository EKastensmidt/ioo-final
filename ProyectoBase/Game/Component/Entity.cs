using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public abstract class Entity 
    {

        private static int _id = 0;
        private int id;

        private Transform transform;
        private Renderer renderer;
        private Collider collider;

        public delegate void OnDestroy(Entity me);


        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Collider Collider { get => collider; set => collider = value; }

        public Entity(Transform transform,Renderer renderer,Collider collider)
        {
            this.transform = transform;
            this.renderer = renderer;
            this.collider = collider;

            this.id = Entity._id;
            Entity._id++;

        }

        public event OnDestroy OnDestroyInstance;

        public void Render()
        {
            this.Renderer.Draw(this.Transform);
        }

        public override bool Equals(object e)
        {
            return this.id == ((Entity)e).id;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public void CheckCollisions(List<Entity> entities) 
        {

            Entity[] temp = new Entity[entities.Count];
            entities.CopyTo(temp);
            collider.CheckCollisions(temp, this);
        }

        public void Destroy()
        {
            OnDestroyInstance(this);
        }

        public abstract void onCollision(Entity e);
        public abstract void Update();
    }
}
