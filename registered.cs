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
    public partial class registered : Form
    {
        public registered()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registered();
        }
        public void Registered()
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "")
            {
                Dao dao = new Dao();
                string sql = $"insert into t_User values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','初级',100)";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("注册成功！请退出注册界面登陆！");

                }
                else
                {
                    MessageBox.Show("注册失败！请尝试修改账号名或其他！");
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("输入不能为空！");
            }
        }

        private void registered_Load(object sender, EventArgs e)
        {

        }
    }
}
