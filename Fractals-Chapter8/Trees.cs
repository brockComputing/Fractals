using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals_Chapter8
{
    public partial class Trees : Form
    {
        public Trees()
        {
            InitializeComponent();
        }
        static Random rnd = new Random();
        private void Trees_Load(object sender, EventArgs e)
        {
            // this.BackColor = Color.Black;
            Pen pen = new Pen(Color.LightCyan, 1);
            WindowState = FormWindowState.Maximized;
        }


        public void RotateExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);

            //Draw the rectangle to the screen before applying the transform.
            e.Graphics.DrawRectangle(myPen, 200, 100, 200, 100);
            Point centre = new Point(300, 150);

            for (int i = 0; i < 360; i++)
            {
                System.Threading.Thread.Sleep(100);
                e.Graphics.Clear(this.BackColor);
                e.Graphics.Transform = RotateAroundPoint(i, centre);
                e.Graphics.DrawRectangle(myPen, 200, 100, 200, 100); 
            }

            //for (int i = 0; i < 360; i++)
            //{
            //    // Create a matrix and rotate it 45 degrees.
            //    Matrix myMatrix = new Matrix();
            //    myMatrix.Rotate(i, MatrixOrder.Append);

            //    // Draw the rectangle to the screen again after applying the

            //    // transform.
            //    e.Graphics.Transform = myMatrix;
            //    e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100);
            //    e.Graphics.ResetTransform();
            //    e.Graphics.DrawLine(Pens.Black, 100, 100, 1000, 1000);
            //}
            // !!!!!!!!!!!!!!! this by far the best method!!!!!!!!!!!!! below

           

            // Draw the rectangle to the screen before applying the transform.
            e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100);
            e.Graphics.TranslateTransform(150, 50);
            e.Graphics.DrawRectangle(Pens.Orange, 10, 10, 200, 100);
            // Create a matrix and rotate it 45 degrees.
            e.Graphics.RotateTransform(30);

            e.Graphics.DrawRectangle(myPen2, 0, 0, 200, 100);

        }

        private Matrix RotateAroundPoint(float angle, Point center)
        {
            // Translate the point to the origin.
            Matrix result = new Matrix();
            result.RotateAt(angle, center);
            return result;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            // RotateExample(e);
            SimpleTree(e);
        }

        private void SimpleTree(PaintEventArgs e)
        {
            float len = 300;

            //for (int i = 0; i < 100; i++)
            //{
            //    Color treeColor = Color.FromArgb(rnd.Next(0, 256), 255, rnd.Next(0, 256));
            //    e.Graphics.TranslateTransform(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
            //    Branch(e, len, treeColor);
            //    e.Graphics.ResetTransform();
            //}
            e.Graphics.TranslateTransform(this.Width / 2, this.Height);
            Branch(e, len, Color.BlueViolet);
        }

        private void Branch(PaintEventArgs e, float len, Color treeColor)
           
        {
            float theata;
            Pen pen = new Pen(Brushes.LimeGreen);
            pen.Color = treeColor;
            pen.Width = len * 1 / 20;
            GraphicsState graphicsState;
            e.Graphics.DrawLine(pen, 0, 0, 0, -len);
            pen.Width = pen.Width * 0.66F;
            e.Graphics.TranslateTransform(0, -len);
            len = len * 0.66F;
            if (len > 2.0F)
            {
                
                graphicsState = e.Graphics.Save();
                theata = rnd.Next(0, 60);
                e.Graphics.RotateTransform(theata);
                Branch(e, len, treeColor );
                e.Graphics.Restore(graphicsState);
                graphicsState = e.Graphics.Save();
                theata = rnd.Next(10, 60);
                e.Graphics.RotateTransform(-theata);
                Branch(e, len, treeColor );
                e.Graphics.Restore(graphicsState);

            }
        }

       
    }
}
