using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Fractals_Chapter8
{



    public partial class KochCurveV2 : Form
    {
        List<KochLine> lines = new List<KochLine>();
        
        Random rnd = new Random();



        class KochLine
        {
            Vector2 start = new Vector2();
            Vector2 end = new Vector2();
            Pen thepen = new Pen(Color.BlueViolet, 1);
            public KochLine(Vector2 a, Vector2 b, Pen pen)
            {
                start = a;
                end = b;
                thepen = pen;
            }





            public void Display(Graphics graphics)
            {
                graphics.DrawLine(thepen, start.X, start.Y, end.X, end.Y);
            }
            public Vector2 KochA()
            {
                return start;
            }

            public Vector2 KochB()
            {
                Vector2 v = end - start;
                v = v / 3;
                v = v + start;
                return v;
            }

            public Vector2 KochC()
            {

                Vector2 a = start;
                Vector2 v = end - start;
                v = v / 3;
                a = a + v;
                v = Rotate(v, -60);

                a = a + v;
                return a;
            }


            public Vector2 KochF()
            {
                Vector2 a = start;

                Vector2 v = end - start;
                v = v / 3;
                a = a + v;
                v = Rotate(v, 60);
                a = a + v;
                return a;
            }

            public Vector2 KochD()
            {
                Vector2 v = end - start;
                v = v * 2 / 3;
                v = v + start;
                return v;
            }

            public Vector2 KochE()
            {
                return end; ;
            }

            public Vector2 Rotate(Vector2 v, float degrees)
            {
                float radians = degrees * (float)Math.PI / 180;
                float ca = (float)Math.Cos(radians);
                float sa = (float)Math.Sin(radians);
                return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
            }


        }


        public KochCurveV2()
        {
            InitializeComponent();
        }

        private void KochCurve_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            Pen pen = new Pen(Color.LightCyan, 1);
            WindowState = FormWindowState.Maximized;
            Vector2 start = new Vector2(0, 450);
            Vector2 end = new Vector2(this.Width, 450);
            lines.Add(new KochLine(start, end, pen));
            for (int i = 0; i < 6; i++)
            {
                Generate();
            }
        }

        private void Generate()
        {
            List<KochLine> next = new List<KochLine>();
            Color rndColor;
            //rndColor = rndColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            //Pen normalPen = new Pen(rndColor, 1);
            Pen normalPen = new Pen(Color.BlueViolet , 1);
            Pen clearPen = new Pen(this.BackColor, 1);
            foreach (var l in lines)
            {
                Vector2 a = l.KochA();
                Vector2 b = l.KochB();
                Vector2 c = l.KochC();
                Vector2 d = l.KochD();
                Vector2 e = l.KochE();
                Vector2 f = l.KochF();

                next.Add(new KochLine(a, b, normalPen));
                next.Add(new KochLine(b, c, normalPen));
                next.Add(new KochLine(c, d, normalPen));
                next.Add(new KochLine(d, e, normalPen));
                next.Add(new KochLine(b, f, normalPen));
                next.Add(new KochLine(f, d, normalPen));
                next.Add(new KochLine(b, d, normalPen));
                next.Add(new KochLine(c, e, normalPen));
            }
            lines.Clear();
            lines = next.ToList();
            //Graphics graphics = this.CreateGraphics();
            //foreach (var l in lines)
            //{
            //    l.Display(graphics);
            //}
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var l in lines)
            {
                l.Display(e.Graphics);
            }
        }
    }
}
