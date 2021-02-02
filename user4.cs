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
    public partial class user4 : Form
    {
        public user4()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select bid, name, time from v_yuyue where uid='{Data.UID}'";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                string[] table = { a0, a1, a2 };
                dataGridView1.Rows.Add(table);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void user4_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id2 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  //获取书号
                DialogResult dr = MessageBox.Show("确认取消预约吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_reserve where uid='{Data.UID}' and bid='{id2}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("取消成功！");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("取消失败！");
                    }
                    dao.DaoClose();
                    Table();
                }
            }
            catch
            {

            }
        }
    }
}
