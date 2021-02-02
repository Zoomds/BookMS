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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user1 user1 = new user1();
            user1.ShowDialog();
        }

        private void user_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user2 user2 = new user2();
            user2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user3 user3 = new user3();
            user3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user4 user4 = new user4();
            user4.ShowDialog();
        }
    }
}
