using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class Curve : GraphicObject
    {
        public List<Line> Lines { get; set; }

        public Curve()
        {
            Lines = new List<Line>();
        }

        public Curve(List<Line> lines)
        {
            Lines = lines;
        }

#if UnityConfig

        public override GameObject Draw()
        {
            var curve = new GameObject("Curve");

            foreach (var line in Lines)
            {
                try
                {
                    line.Draw().transform.parent = curve.transform;
                }
                catch (Exception)
                {
                    
                }
                
            }

            return curve;
        }

#endif

        
    }
}
