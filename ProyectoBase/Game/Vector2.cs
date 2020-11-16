using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Vector2
    {
        private float x;
        private float y;

        public static Vector2 Zero => new Vector2(0, 0);

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x + vector2.x, vector1.y + vector2.y);
        }

        public static bool operator ==(Vector2 vector1, Vector2 vector2)
        {
            return vector1.x == vector2.x && vector1.y == vector2.y;
        }

        public static bool operator !=(Vector2 vector1, Vector2 vector2)
        {
            return vector1.x != vector2.x || vector1.y != vector2.y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
