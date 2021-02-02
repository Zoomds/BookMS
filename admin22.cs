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
    public partial class admin22 : Form
    {
        string NO = "";
        public admin22()
        {
            InitializeComponent();
        }
        public admin22(string No, string Sort, string Authnum, string ISBN, string NUM, string Worker, string CDate)
        {
            InitializeComponent();
            NO=textBox1.Text = No;
            textBox2.Text = Sort;
            textBox3.Text = Authnum;
            textBox4.Text = ISBN;
            textBox5.Text = NUM;
            textBox6.Text = Worker;
            textBox7.Text = CDate;
        }

        private void admin22_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string sql = $"update C_Data set No='{textBox1.Text}',Sort='{textBox2.Text}',Authnum='{textBox3.Text}',ISBN='{textBox4.Text}' ,NUM='{textBox5.Text}', Worker='{textBox6.Text}',CDate='{textBox7.Text}' where No='{NO}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
         }
    }

}
