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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        double RUB;
        double kursUSD;
        double USD;
        double kursEURO;
        double EURO;
        double kursCNY;
        double CNY;
        double kursBTC;
        double BTC;
        DateTime date;
        private void button1_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            RUB = System.Convert.ToDouble(textBox1.Text);
            System.IO.StreamReader sm;
            sm = new System.IO.StreamReader(Application.StartupPath + "\\kursVAL.text", System.Text.Encoding.GetEncoding(65001));
            string st1, st2, st3, st4 = "";
            while (!sm.EndOfStream) 
            { 
                st1 = sm.ReadLine(); 
                kursUSD = System.Convert.ToDouble(st1); 
                USD = RUB/ kursUSD; 
                st2 = sm.ReadLine(); 
                kursEURO = System.Convert.ToDouble(st2); 
                EURO = RUB/ kursEURO; 
                st3 = sm.ReadLine(); 
                kursCNY = System.Convert.ToDouble(st3); 
                CNY = RUB/ kursCNY;
                st4 = sm.ReadLine();
                kursBTC = System.Convert.ToDouble(st4);
                BTC = RUB/ kursBTC;
            }
            sm.Close();
            System.IO.FileInfo fi = new System.IO.FileInfo(Application.StartupPath + "\\val.text");
            System.IO.StreamWriter sw;
            if (fi.Exists)
            {
                sw = fi.AppendText();
            }
            else
            {
                sw = fi.CreateText();
            }
            sw.WriteLine(date.ToShortDateString());
            sw.WriteLine(RUB.ToString("N"));
            sw.WriteLine(USD.ToString("N"));
            sw.WriteLine(EURO.ToString("N"));
            sw.WriteLine(CNY.ToString("N"));
            sw.WriteLine(BTC.ToString("N"));
            sw.Close();
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}