using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yilanOyunu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yilanOyunu form = new yilanOyunu();
            form.ShowDialog();
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random renk=new Random();
            button1.BackColor = Color.FromArgb(renk.Next(100, 200), renk.Next(100, 200), renk.Next(100, 200));
            button2.BackColor = Color.FromArgb(renk.Next(100, 200), renk.Next(100, 200), renk.Next(100, 200));
        }
    }
}
