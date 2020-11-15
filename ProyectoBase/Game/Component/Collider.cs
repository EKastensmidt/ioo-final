using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Collider
    {
        private bool IsBetween(float value, float a, float b)
        {
            return (value > a && value < b) || (value < a && value > b);
        }
        public bool IsColliding(Entity a, Entity b)
        {
            float direction = GetDirection(a.Transform.Position, b.Transform.Position);
            float distance = GetDistance(a.Transform.Position, b.Transform.Position);
            if (IsBetween(direction, 45, 135) || IsBetween (direction,225,315))
            {
                return distance < (a.Renderer.TileHeight / 2) + (b.Renderer.TileHeight / 2);
            }
            return distance < (a.Renderer.TileWidth / 2) + (b.Renderer.TileWidth / 2);
        }
        
        public float GetDirection(Vector2 a, Vector2 b)
        {
            float adjacent = b.X - a.X;
            float opposite = b.Y - a.Y;
            float Hypotenuse = (float) Math.Sqrt(Math.Pow(adjacent, 2) + Math.Pow(opposite, 2));
            float degree;
            if(adjacent!=0 && opposite != 0)
            {
                degree = (float)Math.Atan(opposite / adjacent);
            }
            else if(adjacent!= 0 && Hypotenuse != 0)
            {
                degree = (float)Math.Acos(adjacent / Hypotenuse);
            }
            else
            {
                degree = (float)Math.Asin(opposite / Hypotenuse);
            }
            if(adjacent>=0 || opposite == 0)
            {
                return degree * 180 / (float)Math.PI;
            }
            return (degree * 180 / (float)Math.PI)+180;
        }
        public float GetDistance(Vector2 a,Vector2 b)
        {
            float adjacent = b.X - a.X;
            float opposite = b.Y - a.Y;
            return (float)Math.Sqrt(Math.Pow(adjacent, 2) + Math.Pow(opposite, 2));
        }
    }
}
