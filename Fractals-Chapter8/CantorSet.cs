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
    public partial class CantorSet : Form
    {
        
        public CantorSet()
        {
            InitializeComponent();
        }

        private void CantorSet_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            


        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            float x = 0.0f, y = 10.0f, length = this.Width - 100;
            Cantor(x, y, length, e.Graphics);
        }

        private void Cantor(float x, float y, float length, Graphics graphics)
        {
            
            // DialogResult dialogResult = MessageBox.Show("another","kj", MessageBoxButtons.YesNo);
            if (length > 1 )
            {
                System.Threading.Thread.Sleep(100);
                graphics.DrawLine(new Pen(Color.BlueViolet, 10), x, y, x + length, y);
                y += 20;
                Cantor(x, y, length / 3, graphics);
                Cantor(x + length  * 2.0f / 3.0f , y, length / 3.0f, graphics); 
            }
        }
    }
}
