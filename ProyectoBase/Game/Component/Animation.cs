using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        private int frames;
        private double speed;
        private bool loop;
        private int index;

        public Animation(bool loop, double speed, int frames, int index)
        {
            this.loop = loop;
            this.speed = speed;
            this.frames = frames;
            this.Index = index;
        }

        public int Index { get => index; set => index = value; }

        public int CurrentFrame(DateTime startTime)
        {
            double deltaTime = (DateTime.Now - startTime).TotalMilliseconds;
            if (!loop && deltaTime > speed * frames) return -1;
            return ((int) Math.Floor(deltaTime / speed)) % frames;
        }
    }
}
