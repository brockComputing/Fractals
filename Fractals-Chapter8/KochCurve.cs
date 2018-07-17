//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Numerics;

//namespace Fractals_Chapter8
//{
//    public static class VectorExt
//    {
//        private const float DegToRad =(float) Math.PI / 180;

//        public static Vector2 Rotate(this Vector2 v, float degrees)
//        {
//            return v.RotateRadians(degrees * DegToRad);
//        }

//        public static Vector2 RotateRadians(this Vector2 v, float radians)
//        {
//            float ca =(float) Math.Cos(radians);
//            float sa = (float)Math.Sin(radians);
//            return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
//        }

       
//    }


//    public partial class KochCurveV2 : Form
//    {
//        List<KochLine> lines = new List<KochLine>();
//        List<KochLine> next = new List<KochLine>();

        


//        class KochLine
//        {
//            Vector2 start = new Vector2();
//            Vector2 end = new Vector2();
//            public KochLine(Vector2 a, Vector2 b)
//            {
//                start = a;
//                end = b;
//            }

//            public  Vector2 RotateDegreesAroundAPoint(Vector2 v, Vector2 point, float degrees)
//            {
//                Vector2 newVec = new Vector2();
//                float x, y;
//                float radians =(float) degrees * (float)Math.PI / 180;

//                x = ((v.X - point.X) * (float)Math.Cos(radians)) - ((point.Y - v.Y) * (float)Math.Sin(radians));
//                y = ((point.Y - v.Y) * (float)Math.Sin(radians)) + ((v.X - point.X) * (float)Math.Cos(radians));
//                newVec.X = x;
//                newVec.Y = y;
//                return newVec;


//            }

//            public void Display(Graphics graphics)
//            {
//                graphics.DrawLine(Pens.BlueViolet, start.X, start.Y, end.X, end.Y);
//            }
//            public Vector2  KochA()
//            {
//                return start;
//            }

//            public Vector2 KochB()
//            {
//                Vector2 v = end - start;
//                v = v / 3;
//                v = v + start;
//                return v;
//            }

//            public Vector2 KochC()
//            {
//                Vector2 a = start;
                
//                Vector2 v = end - start;
//                v = v / 3;
//                a = a + v;
//                v = VectorExt.Rotate(v, -60);
//                a = a + v;
//                return a;

//                //Vector2 v = end - start;
//                //v = v / 3;
//                //v = v + start;
//                ////v = VectorExt.Rotate(v, -60);
//                ////v = RotateDegreesAroundAPoint(v,start, 60);
//                //v = v + start;
//                //return a;
//            }

//            public Vector2 KochD()
//            {
//                Vector2 v = end - start;
//                v = v * 2/ 3;
//                v = v + start;
//                return v;
//            }

//            public Vector2 KochE()
//            {
//                return end; ;
//            }

           
            

//        }
//        public KochCurveV2()
//        {
//            InitializeComponent();
//        }
        
//        private void KochCurve_Load(object sender, EventArgs e)
//        {
//            WindowState = FormWindowState.Maximized;
//            Vector2 start = new Vector2(0, 400);
//            Vector2 end = new Vector2(this.Width, 400);
//            lines.Add(new KochLine(start, end));
//            for (int i = 0; i < 2; i++)
//            {
//                Generate();
//            }
            
//        }

//        private void Generate()
//        {
//            foreach (var l in lines)
//            {
//                Vector2 a = l.KochA();
//                Vector2 b = l.KochB();
//                Vector2 c = l.KochC();
//                Vector2 d = l.KochD();
//                Vector2 e = l.KochE();

//                next.Add(new KochLine(a,b));
//                next.Add(new KochLine(b, c));
//                next.Add(new KochLine(c, d));
//                next.Add(new KochLine(d, e));
//            }
//            lines.Clear();
//            lines = next.ToList();
//        }

//        private void OnPaint(object sender, PaintEventArgs e)
//        {
//            foreach (var l in lines)
//            {
//                l.Display(e.Graphics);
//            }
//        }
//    }
//}
