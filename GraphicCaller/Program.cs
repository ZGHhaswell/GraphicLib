using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GraphicLib.Data;

namespace GraphicCaller
{
    class Program
    {
        static void Main(string[] args)
        {

            var grapgicSet = new GraphicSet();
            var point = new Point(100, 10, 0);

            var line = new Line(new Point(20, 20, 0), new Point(30, 30, 0));

            var curve = new Curve(new List<Line>()
        {
            new Line(new Point(40,40,0), new Point(50,50,0)),
            new Line(new Point(50, 50, 0),new Point(20, 100, 0)),
            new Line(new Point(20, 100, 0),new Point(20, 111, 0)),
            new Line(new Point(20, 111, 0),new Point(50, 100, 0))
        });


            var trangular = new Trangular()
            {
                FirstLine = new Line(new Point(100, 200, 0), new Point(100, 300, 0)),
                SecondLine = new Line(new Point(100, 300, 0), new Point(300, 300, 0)),
                ThridLine = new Line(new Point(300, 300, 0), new Point(100, 200, 0))
            };

            var face = new Face(new List<Trangular>()
        {
            new Trangular()
            {
                FirstLine = new Line(new Point(0, 0, 10), new Point(100, 0, 10) ),
            
                SecondLine = new Line(new Point(100, 0, 10), new Point(100, 100, 10)),
            
                ThridLine = new Line(new Point(100, 100, 10), new Point(0, 0, 10))
            },
            new Trangular()
            {
                FirstLine = new Line(new Point(0, 0, 10), new Point(100, 100, 10) ),
            
                SecondLine = new Line(new Point(100, 100, 10), new Point(0, 100, 10)),
            
                ThridLine = new Line(new Point(0, 100, 10), new Point(0, 0, 10))
                
            },
        });

            grapgicSet.GraphicObjects.Add(point);
            grapgicSet.GraphicObjects.Add(line);
            grapgicSet.GraphicObjects.Add(curve);
            grapgicSet.GraphicObjects.Add(trangular);
            grapgicSet.GraphicObjects.Add(face);

            XmlUtils<GraphicSet>.ExportToXml(grapgicSet, "D://test.config");

            Process.Start("D://GraphicPreview.exe", string.Format("{0}", "D://test.config"));

        }
    }

    public static class XmlUtils<T>
        where T : class
    {
        public static T ImportFromXml(string filePath)
        {
            T t = null;

            try
            {
                if (File.Exists(filePath))
                {
                    using (Stream stream = new FileStream(filePath, FileMode.Open))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(T));
                        t = xs.Deserialize(stream) as T;
                    }
                }
            }
            catch (Exception)
            {
                //error
                t = null;
            }


            return t;
        }

        public static bool ExportToXml(T t, string filePath)
        {
            bool isSuccess = false;
            try
            {
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(stream, t);
                }
                isSuccess = true;
            }
            catch (Exception e)
            {
                //error
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
