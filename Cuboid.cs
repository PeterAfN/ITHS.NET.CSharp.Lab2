using System.Numerics;
using System;

namespace ShapeLibrary
{
    public class Cuboid : Shape3D
    {
        private readonly Vector3 center;
        private readonly Vector3 size;

        public Cuboid(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
        }

        public Cuboid(Vector3 center, float width)
        {
            this.center = center;
            size.X = width;
            size.Y = width;
            size.Z = width;
        }

        public override float Volume
        {
            get
            {
                return MathF.Abs( size.X * size.Y * size.Z );
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
                return  2 * (MathF.Abs(size.X * size.Y) + MathF.Abs(size.X * size.Z) + MathF.Abs(size.Y * size.Z) );
            }
        }

        public bool IsCube 
        {
            get
            {
                return size.X == size.Y && size.Y == size.Z;
            }        
        }

        public override string ToString()
        {
            if (IsCube)
                return $"cube @({center.X:0.0}, {center.Y:0.0}, {center.Z:0.0}): w = " +
                    $"{size.X:0.0}, h = {size.Y:0.0}, l = {size.Z:0.0}";
            else
                return $"cuboid @({center.X:0.0}, {center.Y:0.0}, {center.Z:0.0}): w = " +
                    $"{size.X:0.0}, h = {size.Y:0.0}, l = {size.Z:0.0}";
        }
    }
}
