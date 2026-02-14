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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "пришел";
            button2.Text = "ушел";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Text = "пришел";
            button1.Text = "ушел";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
