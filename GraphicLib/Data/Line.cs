
using System;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class Line : GraphicObject
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }


        public Line()
        {
            
        }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

#if UnityConfig

        private static UnityEngine.Object _linePrefab;
        public static UnityEngine.Object LinePrefab
        {
            get
            {
                return _linePrefab ?? (_linePrefab = Resources.Load("Line"));
            }
        }

        public override GameObject Draw()
        {
            var lineObject = GameObject.Instantiate(LinePrefab) as GameObject;
            var lineRender = lineObject.GetComponent("LineRenderer") as LineRenderer;
            lineRender.SetVertexCount(2);
            lineRender.SetPosition(0, StartPoint.ToVector3());
            lineRender.SetPosition(1, EndPoint.ToVector3());

            SetStartPoint(StartPoint.ToVector3());

            return lineObject;
        }

#endif 
    }
}
