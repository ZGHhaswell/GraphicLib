
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    [XmlInclude(typeof(Point)), 
    XmlInclude(typeof(Face)), 
    XmlInclude(typeof(Line)),
    XmlInclude(typeof(Curve)), 
    XmlInclude(typeof(GraphicSet)), 
    XmlInclude(typeof(Trangular))]
    public abstract class GraphicObject
    {

#if UnityConfig

        public abstract GameObject Draw();

        private static Vector3 _startPoint = Vector3.zero;

        public Vector3 GetStartPoint()
        {
            return _startPoint;
        }

        protected void SetStartPoint(Vector3 startPoint)
        {
            if (_startPoint.Equals(Vector3.zero))
            {
                _startPoint = startPoint;
            }
        }

#endif

        protected GraphicObject()
        {
            
        }
    }
}
