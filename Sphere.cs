using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Sphere : Shape3D
    {
        private readonly Vector3 center;
        private readonly float radius;

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = MathF.Abs(radius);
        }

        public override float Volume
        {
            get
            {
                return 4.00f/3.00f*MathF.PI*MathF.Pow(radius, 3);
            }
        }

        public override Vector3 Center
        {
            get
            {
                return center;
            }
        }

        public override float Area
        {
            get
            {
                return 4 * MathF.PI * MathF.Pow(radius, 2);
            }
        }

        public override string ToString()
        {
            return $"sphere @({center.X:0.0}, {center.Y:0.0}, {center.Z:0.0}): r = {radius:0.0}";
        }
    }
}
