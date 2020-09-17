using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConvertVAL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(Application.StartupPath + "\\val.text", System.Text.Encoding.GetEncoding(65001));
                DateTime dateStart = monthCalendar1.SelectionStart;
                DateTime dateEnd = monthCalendar1.SelectionEnd;
                string st1, st2, st3, st4, st5, st6 = "";
                DateTime date;
                double RUB;
                double USD;
                double EURO;
                double CNY;
                double BTC;
                listBox1.Items.Clear();
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
                chart1.Series[0].Points.Clear();
                while (!sr.EndOfStream)
                {
                    st1 = sr.ReadLine();
                    date = System.Convert.ToDateTime(st1);
                    st2 = sr.ReadLine();
                    RUB = System.Convert.ToDouble(st2);
                    st3 = sr.ReadLine();
                    USD = System.Convert.ToDouble(st3);
                    st4 = sr.ReadLine();
                    EURO = System.Convert.ToDouble(st4);
                    st5 = sr.ReadLine();
                    CNY = System.Convert.ToDouble(st5);
                    st6 = sr.ReadLine();
                    BTC = System.Convert.ToDouble(st6);
                    listBox1.Items.Add(st1.PadLeft(0)+ " " + st2.PadLeft(15) + " " + st3.PadLeft(20) + " " + st4.PadLeft(20) + " " + st5.PadLeft(20) + " " + st6.PadLeft(20));
                    chart1.Series[0].Points.AddXY(st1, RUB);
                    chart1.Series[1].Points.AddXY(st2, USD);
                    chart1.Series[2].Points.AddXY(st3, EURO);
                    chart1.Series[3].Points.AddXY(st4, CNY);
                    chart1.Series[4].Points.AddXY(st5, BTC);
                }
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error property file" + exc.ToString(), "Quotation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                button1.Enabled = false;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}