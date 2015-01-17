using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class GraphicSet : GraphicObject
    {
        public List<GraphicObject> GraphicObjects { get; set; }

        public GraphicSet()
        {
            GraphicObjects = new List<GraphicObject>();
        }

#if UnityConfig

        public override GameObject Draw()
        {
            var graphicObject = new GameObject("GraphicSet");

            foreach (var o in GraphicObjects)
            {
                try
                {
                    o.Draw().transform.parent = graphicObject.transform;
                }
                catch (Exception)
                {
                    
                }
                
            }
            return graphicObject;
        }

#endif 
    }
}
