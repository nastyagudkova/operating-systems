using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private bool mouseOnPicture = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            mouseOnPicture = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseOnPicture = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseOnPicture) return;

            Point mouseOnForm = this.PointToClient(Cursor.Position);

            int newX = mouseOnForm.X - pictureBox1.Width / 2;
            int newY = mouseOnForm.Y - pictureBox1.Height / 2;

            int maxX = this.ClientSize.Width - pictureBox1.Width;
            int maxY = this.ClientSize.Height - pictureBox1.Height;

            if (newX < 0) newX = 0;
            if (newY < 0) newY = 0;
            if (newX > maxX) newX = maxX;
            if (newY > maxY) newY = maxY;

            pictureBox1.Location = new Point(newX, newY);
        }
    }
}
