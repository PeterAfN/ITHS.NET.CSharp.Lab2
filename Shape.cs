using System;
using System.Numerics;

namespace ShapeLibrary
{
    public abstract class Shape
    {

        public abstract Vector3 Center { get; }

        public abstract float Area { get; }

        public static Shape GenerateShape()
        {
            return GetRndShapeWithRndValues();
        }

        public static Shape GenerateShape(Vector3 center)
        {
            return GetRndShapeWithRndValues(false, center);
        }

        public static Shape CurrentShape;
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// If parameter setRandomCenter is set to true (default), the centerXYZ is ignored by the method.
        /// </summary>
        /// <param name="setRandomCenter"></param>
        /// <param name="centerXyz"></param>
        /// <returns></returns>
        private static Shape GetRndShapeWithRndValues(bool setRandomCenter = true, Vector3 centerXyz = default)
        {
            var centerXy = new Vector2(centerXyz.X, centerXyz.Y);
            if (setRandomCenter)
            {
                centerXyz = RndVect3();
                centerXy = RndVect2();
            }
            switch (Rnd.Next(7))
            {
                case 0:
                    CurrentShape = new Circle(centerXy, RndFloat());                       //2D circle
                    return CurrentShape;
                case 1:
                    CurrentShape = new Rectangle(centerXy, RndVect2());                     //2D rectangle
                    return CurrentShape;
                case 2:
                    CurrentShape = new Rectangle(centerXy, RndFloat());                    //2D square
                    return CurrentShape;
                case 3:
                    if (setRandomCenter)
                    {
                        CurrentShape = new Triangle(RndVect2(), RndVect2(), RndVect2());        //2D triangle - random
                        return CurrentShape;
                    }              
                    else
                    {
                        Vector2 aXy = RndVect2();
                        Vector2 bXy = RndVect2();
                        Vector2 cXy = GetTriangleThirdCoord(centerXy, aXy, bXy);
                        CurrentShape = new Triangle(aXy, bXy, cXy);                             //2D triangle - not random
                        return CurrentShape;
                    }
                case 4:
                    CurrentShape = new Cuboid(centerXyz, RndVect3());                       //3D cuboid
                    return CurrentShape;
                case 5:
                    CurrentShape = new Cuboid(centerXyz, RndFloat());                      //3D cube
                    return CurrentShape;
                case 6:
                    CurrentShape = new Sphere(centerXyz, RndFloat());                     //3D sphere
                    return CurrentShape;
            }
            return null;
        }

        private static Vector2 GetTriangleThirdCoord(Vector2 xyCenter, Vector2 aXy, Vector2 bXy)
        {
            //https://study.com/academy/lesson/how-to-find-the-centroid-of-a-triangle.html
            Vector2 cXy;
            cXy.X = 3 * xyCenter.X - aXy.X - bXy.X;
            cXy.Y = 3 * xyCenter.Y - aXy.Y - bXy.Y;
            return cXy;
        }

        public const int Min = -10;
        public const int Max = 10;

        private static float RndFloat()
        {
            return (float) ( Min + ( Rnd.NextDouble() * ( Max - Min ) ) );
        }

        private static Vector2 RndVect2()
        {
            return new Vector2( RndFloat(), RndFloat() );
        }

        private static Vector3 RndVect3()
        {
            return new Vector3( RndFloat(), RndFloat(), RndFloat() );
        }
    }
}
