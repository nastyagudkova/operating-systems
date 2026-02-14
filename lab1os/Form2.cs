using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            double number;
            bool ok =
                double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out number) ||
                double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out number);

            if (ok)
            {
                number += 2;
                textBox1.Text = number.ToString("G", CultureInfo.CurrentCulture);
            }
            else
            {
                textBox1.Text = "доступен только ввод чисел";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
