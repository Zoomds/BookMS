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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
            Dao dao = new Dao();
            string sql = $"select * from t_user where Uid='{Data.UID}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                textBox1.Text = dc[0].ToString();
                textBox2.Text = dc[1].ToString();
                textBox3.Text = dc[2].ToString();
                textBox4.Text = dc[3].ToString();
                textBox5.Text = dc[4].ToString();
                textBox6.Text = dc[5].ToString();
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_User set Upsw='{textBox2.Text}'where Uid='{Data.UID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }
    }
}
