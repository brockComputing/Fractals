using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals_Chapter8
{
    public partial class Circles : Form
    {
        public Circles()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

       

        private void drawCircleUsingCentrePoint(int x, int y, int radius, Graphics graphics)
        {
            //System.Threading.Thread.Sleep(100);
            Rectangle rect = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            graphics.DrawEllipse(Pens.Black, rect);
            if (radius > 3)
            {
               // radius = Convert.ToInt32( radius * 0.75) ;
                //drawCircleUsingCentrePoint(x, y, radius, graphics); // oringinal
                drawCircleUsingCentrePoint(x + radius / 2, y, radius / 2, graphics);
                drawCircleUsingCentrePoint(x - radius / 2 , y, radius / 2, graphics);
                drawCircleUsingCentrePoint(x, y + radius / 2, radius / 2, graphics);
                drawCircleUsingCentrePoint(x, y - radius / 2, radius / 2, graphics);
            }
        }

        private void drawCircle(int x, int y, int radius, Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, x, y, radius, radius);
            if (radius > 5)
            {
                radius -= 10;
                drawCircle(x, y, radius, graphics);
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            int radius = 700;
            int y = (this.ClientRectangle.Height / 2) - (radius / 2);
            int x = (this.ClientRectangle.Width / 2) - (radius / 2);
            // drawCircle(x, y, radius, graphics);
            y = (this.ClientRectangle.Height / 2);
            x = (this.ClientRectangle.Width / 2);
            drawCircleUsingCentrePoint(x, y, radius, e.Graphics);
        }
    }
}
