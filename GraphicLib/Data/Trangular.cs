using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace GraphicLib.Data
{
    [XmlType]
    public class Trangular : GraphicObject
    {
        public Line FirstLine { get; set; }

        public Line SecondLine { get; set; }

        public Line ThridLine { get; set; }


#if UnityConfig

        private static UnityEngine.Object _trangulaPrefab;
        public static UnityEngine.Object TrangularPrefab
        {
            get
            {
                return _trangulaPrefab ?? (_trangulaPrefab = Resources.Load("Trangular"));
            }
        }


        public override GameObject Draw()
        {
            var trangularObject = GameObject.Instantiate(TrangularPrefab) as GameObject;
            MeshFilter meshFilter = trangularObject.GetComponent("MeshFilter") as MeshFilter;

            Mesh mesh = meshFilter.mesh;

            mesh.vertices = new Vector3[] { FirstLine.StartPoint.ToVector3(), SecondLine.StartPoint.ToVector3(), ThridLine.StartPoint.ToVector3()};

            mesh.triangles = new int[] { 0, 1, 2};


            SetStartPoint(FirstLine.StartPoint.ToVector3());

            return trangularObject;
        }

#endif
    }
}
