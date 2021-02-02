using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin1 admin1 = new admin1();
            admin1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin3 admin3 = new admin3();
            admin3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin2 admin2 = new admin2();
            admin2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            admin5 admin5 = new admin5();
            admin5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin4 admin4 = new admin4();
            admin4.ShowDialog();
        }
    }
}
