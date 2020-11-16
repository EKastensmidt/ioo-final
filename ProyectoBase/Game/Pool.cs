using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Pool
    {
        private List<Entity> used;
        private Queue<Entity> unused;

        public List<Entity> Used { get => used; }

        public Pool()
        {
            used = new List<Entity>();
            unused = new Queue<Entity>();
        }
        public Entity Get()
        {
            if (unused.Count > 0)
            {
                Entity el = unused.Dequeue();
                el.OnDestroyInstance += OnDestroyHandle;
                Used.Add(el);
                return el;
            }
            return null;
        }
        public void Add(Entity t)
        {
            Used.Add(t);
            t.OnDestroyInstance += OnDestroyHandle;
        }

        public void Render()
        {
            foreach (Entity e in used)
            {
                e.Render();
            }
        }

        public void Update()
        {
            Entity[] temp = new Entity[used.Count];
            used.CopyTo(temp);
            foreach (Entity e in temp)
            {
                e.Update();
            }
        }

        public void OnDestroyHandle(Entity t)
        {
            t.OnDestroyInstance -= OnDestroyHandle;
            unused.Enqueue(t);
            used.Remove(t);
        }
    }
}
