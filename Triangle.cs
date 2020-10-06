using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ShapeLibrary
{
    public class Triangle : Shape2D , IEnumerator, IEnumerable
    {
        private readonly Vector2 p1;
        private readonly Vector2 p2;
        private readonly Vector2 p3;

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            //For IEnumerator and IEnumerable
            trianglePoints.Clear();
            trianglePoints.Add(p1);
            trianglePoints.Add(p2);
            trianglePoints.Add(p3);
        }

        public override float Circumference
        {
            get
            {
                return GetCircumference(p1, p2, p3);
            }
        }

        public override Vector3 Center
        {
            get
            {
                return new Vector3( (p1.X + p2.X + p3.X)/3.00f, 
                    (p1.Y + p2.Y + p3.Y)/3.00f, 0 );
            }
        }

        public override float Area
        {
            get
            {
                return MathF.Abs( GetArea(p1, p2, p3) );
            }
        }

        private float GetCircumference(Vector2 po1, Vector2 po2, Vector2 po3)
        {
            return Distance2Points(po1, po2) +
                   Distance2Points(po2, po3) +
                   Distance2Points(po3, po1);
        }

        private float Distance2Points(Vector2 po1, Vector2 po2)
        {
            return MathF.Sqrt( MathF.Pow(po2.X-po1.X, 2)+
                               MathF.Pow(po2.Y-po1.Y, 2) );
        }

        private static float GetArea(Vector2 po1, Vector2 po2, Vector2 po3)
        {
            return 1.00f/2.00f * ( po1.X*(po2.Y-po3.Y) + po2.X*(po3.Y-po1.Y) + 
                                   po3.X*(po1.Y-po2.Y) );
            //https://ncalculators.com/geometry/triangle-area-by-3-points.htm
        }

        public override string ToString()
        {
            return $"triangle @({Center.X:0.0}, {Center.Y:0.0}): p1({p1.X:0.0}, {p1.Y:0.0}), " +
                $"p2({p2.X:0.0}, {p2.Y:0.0}), p3({p3.X:0.0}, {p3.Y:0.0})";
        }

        #region  IEnumerator/IEnumerable

        private readonly List<Vector2> trianglePoints = new List<Vector2>();

        public object Current
        {
            get
            {
                return trianglePoints[count];
            }
        }

        private int count = -1;

        public bool MoveNext()
        {
            return count++ < 2;
        }

        public void Reset()
        {
            count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion  IEnumerator/IEnumerable
    }
}
