using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        private string texturePath;
        private int tileWidth;
        private int tileHeight;
        private string state;
        private string initial;
        private DateTime lastChange;

        private Dictionary<string, Animation> animations;

        public string TexturePath { get => texturePath; set => texturePath = value; }
        public int TileWidth { get => tileWidth; set => tileWidth = value; }
        public int TileHeight { get => tileHeight; set => tileHeight = value; }
        public string State { get => state; set {
                if(value != state)
                {
                    state = value;
                    lastChange = DateTime.Now;
                }
        } }

        public Renderer(int w, int h, string path, string state)
        {
            tileHeight = h;
            tileWidth = w;
            texturePath = path;
            initial= state;
            this.state = state;
            lastChange = DateTime.Now;
            animations = new Dictionary<string, Animation>();
        }

        public void addAnimation(string state, Animation anim)
        {
            animations.Add(state, anim);
        }

        public void Draw(Transform transform)
        {
            Animation curr;
            animations.TryGetValue(State, out curr);
            if(curr != null)
            {
                int frame = curr.CurrentFrame(lastChange);
                if (frame == -1)
                {
                    State = initial;
                    frame = 0;
                }
                Engine.Draw(Engine.GetTexture($"{TexturePath}/{State}{frame}"), transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Rotation, tileWidth/2, tileHeight/2);
            } else
            {
                Engine.Draw(Engine.GetTexture($"{TexturePath}/{State}{0}"), transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Rotation, 0, 0);
            }
            
            
        }
    }
}
