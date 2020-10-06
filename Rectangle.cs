using System;
using System.Numerics;

namespace ShapeLibrary
{
    public class Rectangle : Shape2D
    {
        private readonly Vector2 center;
        private readonly Vector2 size;

        public Rectangle(Vector2 center, Vector2 size)
        {
            this.center = center;
            this.size = size;
        }

        public Rectangle(Vector2 center, float width)
        {
            this.center = center;
            size.X = width;
            size.Y = width;
        }

        public override float Circumference
        {
            get
            {
                return  2 * ( MathF.Abs(size.X) + MathF.Abs(size.Y) );
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
                return MathF.Abs( size.X * size.Y );
            }
        }

        public bool IsSquare
        {
            get
            {
                return size.X == size.Y;
            }
        }

        public override string ToString()
        {
            if (IsSquare)
                return  $"square @({center.X:0.0}, {center.Y:0.0}): w = {size.X:0.0}, h = {size.Y:0.0}";
            else
                return $"rectangle @({center.X:0.0}, {center.Y:0.0}): w = {size.X:0.0}, h = {size.Y:0.0}";
        }
    }
}
