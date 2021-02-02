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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
            
            
        }
        //从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空已有数据
            Dao dao = new Dao();
            string sql = " select * from C_Data";
            IDataReader dc = dao.read(sql);//读取结果集
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());
              
            }
            dc.Close();
            dao.DaoClose();
        }
        //查询
        public void TableNo ()
        {
            dataGridView1.Rows.Clear();//清空已有数据
            Dao dao = new Dao();
            string sql = $" select * from C_Data where No='{textBox1.Text}'" ;
            IDataReader dc = dao.read(sql);//读取结果集
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());

            }
            dc.Close();
            dao.DaoClose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    private void admin2_Load_1(object sender, EventArgs e)
        {
            Table();
           label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin21 admin21 = new admin21();
            admin21.ShowDialog();
            Table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            
                string No = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取NO
                

                DialogResult dr = MessageBox.Show("注销？","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question );
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from C_Data where No='{No}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("注销成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("注销失败");
                    }
                    dao.DaoClose();

                }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取NO
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string No= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string Sort = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string Authnum= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string ISBN = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string NUM = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string Worker = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string CDate = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//获取值（参数）
            admin22 admin =new  admin22(No,Sort,Authnum,ISBN,NUM,Worker,CDate);
            admin.ShowDialog();
            Table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableNo();
        }

        private void 多行注销_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.SelectedRows.Count;//选中的行数
            string sql = $"delete  from C_Data where No in (";
            for (int i = 0; i < n; i++)
            {
                sql += $"'{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}',";
            }
            sql = sql.Remove(sql.Length - 1);//删除最后一个，
            sql += ")";
            Dao dao = new Dao();
            if (dao.Execute(sql)> n - 1)
            {
                MessageBox.Show("成功删除");
            }
            Table();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            admin23 admin = new admin23();
            admin.ShowDialog();
        }
    }
}
