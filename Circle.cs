using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Circle : Shape2D
    {
        private readonly Vector2 center;
        private readonly float radius;

        public Circle(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = MathF.Abs(radius);
        }

        public override float Circumference
        {
            get
            {
                return 2 * MathF.PI * radius;
            }
        }

        public override Vector3 Center
        {
            get
            {
                return new Vector3(center, 0);
            }
        }

        public override float Area
        {
            get
            {
                return MathF.PI * MathF.Pow(radius, 2);
            }
        }

        public override string ToString()
        {
            return $"circle @({center.X:0.0}, {center.Y:0.0}): r = {radius:0.0}";
        }
    }
}
