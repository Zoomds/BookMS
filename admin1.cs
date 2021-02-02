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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
          
        }

        private void admin21_Load(object sender, EventArgs e)
        {
            Table();
            label12.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_Buy";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2, a3, a4, a5, a6, a7,a8,a9;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                a5 = dc[5].ToString();
                a6 = dc[6].ToString();
                a7 = dc[7].ToString();
                a8 = dc[8].ToString();
                a9 = dc[9].ToString();
                string[] table = { a0, a1, a2, a3, a4, a5, a6, a7 ,a8,a9};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();//断开连接

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            
            if (textBox8.Text.Length != 13)
            {
                MessageBox.Show("ISBN号为13位！");

            }
            else {
                string sql = $"insert into t_Buy values ('{textBox1.Text}','{textBox2.Text }','{textBox3.Text }','{textBox4.Text }','{textBox5.Text }','{textBox6.Text }','{textBox7.Text }','{textBox8.Text }','{textBox9 .Text }','{textBox10 .Text }') ";
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != ""&&textBox9 .Text !=""&&textBox10 .Text !="")
                {
                    if (dao.Execute(sql) > 0)
                    { //受影响的行数大于0则说明sql语句执行成功

                        MessageBox.Show("添加成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                        
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
                else
                {
                    MessageBox.Show("输入不能为空");
                }
            }
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id  = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
                label12.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除？", "信息提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    string sql = $"delete from t_Buy where Did='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else {
                        MessageBox.Show("删除失败"+sql);
                    }
                    dao.DaoClose();
                }
            }
            catch {
                MessageBox.Show("请先选中要删除的书目!","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label12.Text  = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
