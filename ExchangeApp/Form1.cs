using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugunkur = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(bugunkur);
            string alisdolar = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;
            label9.Text = alisdolar;
            string satisdolar = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
            label10.Text = satisdolar;
            string aliseuro = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexBuying").InnerXml;
            label11.Text = aliseuro;
            string satiseuro = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexSelling").InnerXml;
            label12.Text = satiseuro;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = label9.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = label10.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = label11.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = label12.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double miktar, kur, toplam;
            miktar = Convert.ToDouble(textBox2.Text);
            kur = Convert.ToDouble(textBox1.Text);
            toplam = miktar * kur;
            textBox3.Text = toplam.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(".", ",");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double  kur, toplam;
            int miktar;
            kur = Convert.ToDouble(textBox1.Text);
            toplam = Convert.ToDouble(textBox3.Text);
            miktar = (int)(toplam / kur);
            textBox2.Text = miktar.ToString();
        }
    }
}
