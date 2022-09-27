using Lab6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6__Client_
{
    public partial class Form1 : Form
    {
        WSKAAEntities entity;
        public Form1()
        {
            InitializeComponent();
            entity = new WSKAAEntities
                (
                new Uri("http://localhost:856/StudentSerivce")
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in entity.Student.AsEnumerable())
            {
                this.listView1.Items.Add($"{item.id}. {item.name}");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
