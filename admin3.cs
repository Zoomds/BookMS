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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }

        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
        }
        //从数据库读取流通信息显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from v_liutong";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                string[] table = {a0,a1,a2,a3,a4};
                dataGridView1.Rows.Add(table);
            }
        }
        
        private void 新增记录_Click(object sender, EventArgs e)
        {
            admin31 admin31 = new admin31();
            admin31.ShowDialog();
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  //获取用户号
                string id2 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();  //获取书号
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_lend where uid='{id1}' and bid='{id2}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！"+sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  //获取用户号
                string id2 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();  //获取书号
                string id3 = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();  //获取借阅时间
                admin32 admin32 = new admin32(id1,id2,id3);
                admin32.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("error");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin33 admin33 = new admin33();
            admin33.ShowDialog();
        }
    }
}
