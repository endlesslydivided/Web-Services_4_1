using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab4_Client.Lab4Service;
using Lab4_ASMX.SimplexServer;

namespace Lab4.Client
{
    public partial class ASMX : Form
    {
        Simplex client;

        public ASMX()
        {
            InitializeComponent();
            this.client = new Simplex();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(this.X.Value);
            int y = Convert.ToInt32(this.Y.Value);
            int result = this.client.Add(x, y);
            this.RESULT.Text = $"x + y={result}";

            
        }

        private void CONCAT_Click(object sender, EventArgs e)
        {
            string s = this.textBox1.Text;
            double d = Convert.ToDouble(this.numericUpDown1.Value);
            string result = this.client.Concat(s, d);
            this.RESULT.Text = $"s + d={result}";
        }

        private void SUM_Click(object sender, EventArgs e)
        {
            A a1 = new A() {s = textBox2.Text, k = Convert.ToInt32(numericUpDown1.Value),f = (float)(numericUpDown3.Value) };
            A a2 = new A() { s = textBox3.Text, k = Convert.ToInt32(numericUpDown4.Value), f = (float)(numericUpDown5.Value) };
            A result = this.client.Sum(a1, a2);
            this.RESULT.Text = $"a1 + a2 = {result.s} - {result.k} - {result.f}";
        }
    }
}
