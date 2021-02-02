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
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
        }

        private void user3_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select bid, name, datetime from v_liutong where uid='{Data.UID}'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id2 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  //获取书号
                DialogResult dr = MessageBox.Show("确认还书吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_lend where uid='{Data.UID}' and bid='{id2}'";
                    string sql1 = $"update t_book set number=number+1 where id='{id2}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        if (dao.Execute(sql1) > 0)
                        {
                            MessageBox.Show("还书成功！");
                            Table();
                        }
                        else
                        {
                            MessageBox.Show("还书失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("还书失败！" );
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
