using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

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
            int a = int.Parse(textBox1.Text);
            var b = Convert.ToInt32(textBox2.Text);
            double hasil;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    hasil = a + b;
                    textBox3.Text = Convert.ToString(hasil);
                    break;
                case 1:
                    hasil = a - b;
                    textBox3.Text = Convert.ToString(hasil);
                    break;
                case 2:
                    hasil = a * b;
                    textBox3.Text = Convert.ToString(hasil);
                    break;
                case 3:
                    hasil = a / b;
                    textBox3.Text = Convert.ToString(hasil);
                    break;
            }

        }
    }
}
