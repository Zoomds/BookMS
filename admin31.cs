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
    public partial class admin31 : Form
    {
        public admin31()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""|| textBox2.Text != ""||textBox3.Text != "")
            {
                Dao dao = new Dao();
                string sql = $"insert into t_lend values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("增加成功！");

                }
                else
                {
                    MessageBox.Show("增加失败！");
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("输入不能为空！");
            }
            
        }
    }
}
