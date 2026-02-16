using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSlab1part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int newX = e.X - pictureBox1.Width / 2;
            int newY = e.Y - pictureBox1.Height / 2;

            if (newX < 0)
                newX = 0;

            if (newY < 0)
                newY = 0;

            if (newX + pictureBox1.Width > this.ClientSize.Width)
                newX = this.ClientSize.Width - pictureBox1.Width;

            if (newY + pictureBox1.Height > this.ClientSize.Height)
                newY = this.ClientSize.Height - pictureBox1.Height;

            pictureBox1.Location = new Point(newX, newY);
        }
    }
}
