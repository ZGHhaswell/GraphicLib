using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class Face : GraphicObject
    {
        public List<Trangular> Trangulars { get; set; }

        public Face()
        {
            Trangulars = new List<Trangular>();
        }

        public Face(List<Trangular> trangulars)
        {
            Trangulars = trangulars;
        }

#if UnityConfig

        public override GameObject Draw()
        {
            var face = new GameObject("Face");

            foreach (var trangular in Trangulars)
            {
                try
                {
                    trangular.Draw().transform.parent = face.transform;
                }
                catch (Exception)
                {
                    
                }
                
            }

            return face;
        }

#endif 
    }
}
