using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Habrador_Computational_Geometry
{
    //Standardized methods that are the same for all
    public static class HelpMethods
    {
        //Orient triangles so they have the correct orientation
        public static void OrientTrianglesClockwise(HashSet<Triangle2D> triangles)
        {
            foreach (Triangle2D t in triangles)
            {
                if (!Geometry.IsTriangleOrientedClockwise(t.p1, t.p2, t.p3))
                {
                    t.ChangeOrientation();
                }
            }
        }
        //TODO REMOVE THIS AND MAKE ALL IN 2D
        public static void OrientTrianglesClockwise(HashSet<Triangle> triangles)
        {
            foreach (Triangle t in triangles)
            {
                if (!Geometry.IsTriangleOrientedClockwise(t.p1.XZ(), t.p2.XZ(), t.p3.XZ()))
                {
                    t.ChangeOrientation();
                }
            }
        }



        //Calculate the AABB of a set of points
        public static AABB GetAABB(List<Vector2> points)
        {
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;

            for (int i = 0; i < points.Count; i++)
            {
                Vector2 p = points[i];

                if (p.x < minX)
                {
                    minX = p.x;
                }
                if (p.x > maxX)
                {
                    maxX = p.x;
                }

                if (p.y < minY)
                {
                    minY = p.y;
                }
                if (p.y > maxY)
                {
                    maxY = p.y;
                }
            }

            AABB box = new AABB(minX, maxX, minY, maxY);

            return box;
        }


        //
        // Dimension conversions
        //


        //Convert a list from 2d to 3d if we know it's the y coordinate that's missing
        public static List<Vector3> ConvertListFrom2DTo3D(List<Vector2> list_2d)
        {
            List<Vector3> list_3d = new List<Vector3>();

            foreach (Vector2 point in list_2d)
            {
                list_3d.Add(point.XYZ());
            }

            return list_3d;
        }



        //Convert a list from 3d to 2d if we know it's the y coordinate that should be removed
        public static List<Vector2> ConvertListFrom3DTo2D(List<Vector3> list_3d)
        {
            List<Vector2> list_2d = new List<Vector2>();

            foreach (Vector3 point in list_3d)
            {
                list_2d.Add(point.XZ());
            }

            return list_2d;
        }



        //Convert a hashset from 2d to 3d if we know it's the y coordinate that's missing
        public static HashSet<Vector3> ConvertListFrom2DTo3D(HashSet<Vector2> list_2d)
        {
            HashSet<Vector3> list_3d = new HashSet<Vector3>();

            foreach (Vector2 point in list_2d)
            {
                list_3d.Add(point.XYZ());
            }

            return list_3d;
        }



        //Convert a hashset from 3d to 2d if we know it's the y coordinate that should be removed
        public static HashSet<Vector2> ConvertListFrom3DTo2D(HashSet<Vector3> list_3d)
        {
            HashSet<Vector2> list_2d = new HashSet<Vector2>();

            foreach (Vector3 point in list_3d)
            {
                list_2d.Add(point.XZ());
            }

            return list_2d;
        }
    }
}
