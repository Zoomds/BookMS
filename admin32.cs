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
    

    public partial class admin32 : Form
    {
        string uid = "";
        string bid = "";
        public admin32()
        {
            InitializeComponent();
        }
        public admin32(string id1,string id2,string id3)
        {
            InitializeComponent();
            uid=textBox1.Text = id1;
            bid=textBox2.Text = id2;
            textBox3.Text = id3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_lend set uid='{textBox1.Text}',bid='{textBox2.Text}',[datetime]='{textBox3.Text}' where uid='{uid}' and bid='{bid}'";
            Dao dao = new Dao();
            if (dao.Execute(sql)>0)
            {
                MessageBox.Show("更改成功！");
                this.Close();
            }
        }

        private void admin32_Load(object sender, EventArgs e)
        {

        }
    }
}
