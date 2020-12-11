using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Pool<T> where T : Entity
    {
        private List<T> used;
        private Queue<T> unused;

        public List<T> Used { get => used; }

        public Pool()
        {
            used = new List<T>();
            unused = new Queue<T>();
        }
        public T Get()
        {
            if (unused.Count > 0)
            {
                T el = unused.Dequeue();
                el.OnDestroyInstance += OnDestroyHandle;
                Used.Add(el);
                return el;
            }
            return null;
        }
        public void Add(T t)
        {
            Used.Add(t);
            t.OnDestroyInstance += OnDestroyHandle;
        }

        public void Render()
        {
            foreach (T e in used)
            {
                e.Render();
            }
        }

        public void Update()
        {
            T[] temp = new T[used.Count];
            used.CopyTo(temp);
            foreach (T e in temp)
            {
                e.Update();
            }
        }

        public void OnDestroyHandle<T>(T t) where T : Entity
        {
            t.OnDestroyInstance -= OnDestroyHandle;
            unused.Enqueue(t);
            used.Remove(t);
        }
    }
}
