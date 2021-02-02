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
    public partial class admin412 : Form
    {
        string Uid = "";
        public admin412(string id0, string id1, string id2, string id3, string id4, string id5)
        {
            InitializeComponent();
            Uid = id0;
            textBox1.Text = id1;
            textBox2.Text = id2;
            textBox3.Text = id3;
            textBox4.Text = id4;
            textBox5.Text = id5;
        } 

        private void admin412_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_User set Upsw='{textBox1.Text}',Uname='{textBox2.Text}',sex='{textBox3.Text}',Grade='{textBox4.Text}',Credit='{textBox5.Text}' where Uid='{Uid}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("更改成功！");
                this.Close();
            }else
            {
                MessageBox.Show("更改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
