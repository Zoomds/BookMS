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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入账号");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("请输入密码");
            }
            else
            {
                Login();
            }
        }
        public void Login()
        {
            if(radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_user where Uid='{textBox1.Text}'and Upsw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["Uid"].ToString();
                    Data.UName = dc["Uname"].ToString();
                    MessageBox.Show("登录成功");
                    user user = new user();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
                dao.DaoClose();
            }
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where Aid='{textBox1.Text}'and Apsw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin user = new admin();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
                dao.DaoClose();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registered registered = new registered();
            registered.ShowDialog();
        }
    }
}
