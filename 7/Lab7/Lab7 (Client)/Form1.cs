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
using System.Net;
using System.IO;

namespace Lab4.Client
{
    public partial class WCF : Form
    {
        Simplex client;

        public WCF()
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

            
        }

        private void CONCAT_Click(object sender, EventArgs e)
        {
        
        }

        private void SUM_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:40001/Lab7_Service/Feed1/Student");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseString = reader.ReadToEnd();
            richTextBox1.Text = responseString;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
