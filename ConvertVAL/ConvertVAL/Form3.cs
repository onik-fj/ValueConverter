using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertVAL
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        double kursUSD;
        double kursEURO;
        double kursCNY;
        double kursBTC;
        private void button1_Click(object sender, EventArgs e)
        {
            kursUSD = System.Convert.ToDouble(textBox1.Text);
            kursEURO = System.Convert.ToDouble(textBox2.Text);
            kursCNY = System.Convert.ToDouble(textBox3.Text);
            kursBTC = System.Convert.ToDouble(textBox5.Text);
            System.IO.FileInfo fi2 = new System.IO.FileInfo(Application.StartupPath + "\\kursVAL.text");
            System.IO.StreamWriter sw;
            if (fi2.Exists)
            {
                sw = fi2.CreateText();
            }
            else
            {
                sw = fi2.CreateText();
            }
            sw.WriteLine(kursUSD.ToString("N"));
            sw.WriteLine(kursEURO.ToString("N"));
            sw.WriteLine(kursCNY.ToString("N"));
            sw.WriteLine(kursBTC.ToString("N"));
            sw.Close();
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if ((textBox1.Text.IndexOf(',') != -1) || (textBox1.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if ((textBox2.Text.IndexOf(',') != -1) || (textBox2.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if ((textBox3.Text.IndexOf(',') != -1) || (textBox3.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if ((textBox3.Text.IndexOf(',') != -1) || (textBox3.Text.Length == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }
    }
}
