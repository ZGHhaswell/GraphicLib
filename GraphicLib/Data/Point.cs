

using System;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class Point : GraphicObject
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point()
        {
            
        }

#if UnityConfig

        private static UnityEngine.Object _pointPrefab;
        public static UnityEngine.Object PointPrefab
        {
            get
            {
                return _pointPrefab ?? (_pointPrefab = Resources.Load("Point"));
            }
        }

        public override GameObject Draw()
        {
            var pointObject = GameObject.Instantiate(PointPrefab) as GameObject;
            pointObject.transform.position = ToVector3();

            SetStartPoint(ToVector3());

            return pointObject;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

#endif 

    }
}
