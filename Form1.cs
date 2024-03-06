using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = .2;
        Random rnd = new Random();
        double init_priceUSD, init_priceEUR;

        int days = 0;


        private void btCalculate_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                days = 0;
                timer1.Stop();
            }
            else
            {
             chart1.Series[0].Points.Clear();
             chart1.Series[1].Points.Clear();
             timer1.Start();


            init_priceUSD = (double)valueUSD.Value;
            init_priceEUR = (double)valueEUR.Value;
            chart1.Series[0].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
            chart1.Series[1].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
            chart1.Series[0].Points.AddXY(0, init_priceUSD);
            chart1.Series[1].Points.AddXY(0, init_priceEUR);
            
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            days++;
                init_priceUSD = init_priceUSD * (1 + k * (rnd.NextDouble() - 0.5));
                init_priceEUR = init_priceEUR * (1 + k * (rnd.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(days, (Math.Round(init_priceUSD, 2)));
                chart1.Series[1].Points.AddXY(days, (Math.Round(init_priceEUR, 2)));

                lbDays.Text = days.ToString();
                lbUSD.Text = (Math.Round(init_priceUSD, 2)).ToString("C", CultureInfo.GetCultureInfo("en-US"));
                lbEUR.Text = (Math.Round(init_priceEUR, 2)).ToString() + " \u20AC";
        }

    }
}
