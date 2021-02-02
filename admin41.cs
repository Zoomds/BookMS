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
    public partial class admin41 : Form
    {
        public admin41()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空已有数据
            Dao dao = new Dao();
            string sql = "select * from t_user";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin411 admin411 = new admin411();
            admin411.ShowDialog();
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin41_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  //获取用户号
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_User where uid='{id1}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！" + sql);
                    }
                    dao.DaoClose();
                    Table();
                }
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id0 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string id1 = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();  
                string id2 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();  
                string id3 = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();  
                string id4 = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string id5 = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                admin412 admin412 = new admin412(id0, id1, id2, id3, id4, id5);
                admin412.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
    }
}
