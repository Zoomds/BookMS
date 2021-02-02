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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from t_book";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);
            }
        }
        public void reserve1()
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号
            string sql = $"INSERT INTO t_reserve VALUES('{Data.UID}','{id}','{DateTime.Now}')";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("预约成功！");
            }
            
            dao.DaoClose();
        }
        public void reserve()
        {
            try
            {
                string num = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();            //获取库存
                if (num!="0")
                {
                    DialogResult dr = MessageBox.Show("该书任有库存，是否直接借书？点否预约", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        lend();
                    }
                    else
                    {
                        reserve1();
                    }
                }
                else
                {
                    reserve1();
                }
                
            }
            catch
            {
                MessageBox.Show("你已预约过本书！");
            }
        }
        public void lend()                                   
        {
            try
            {
                string num = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();            //获取库存
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();             //获取书号
                if (num !="0")
                {
                    string sql = $"update t_book set number=number-1 where id='{id}'";
                    string sql1 = $"INSERT INTO t_lend VALUES('{Data.UID}','{id}','{DateTime.Now}')";
                    Dao dao = new Dao();
                    if (dao.Execute(sql1) > 0)
                    {
                        if (dao.Execute(sql) > 0)
                        {
                            MessageBox.Show("借书成功！");
                            Table();
                        }
                        
                    }
                    
                    dao.DaoClose();
                }
                else
                {
                    MessageBox.Show("库存不足，如需要请预约！");
                }
                
            }
            catch
            {
                MessageBox.Show("你已借阅过本书！");
            }
        }
        private void user2_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reserve();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lend();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
