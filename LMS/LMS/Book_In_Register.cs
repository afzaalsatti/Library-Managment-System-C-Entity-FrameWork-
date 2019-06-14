using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LMS
{
    public partial class Book_In_Register : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Book_In_Register()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            string id = textBox1.Text;
            

           
                var mem = model.Member_Master.Where(s => s.Mem_Id == id).FirstOrDefault();
                if (mem != null)
                {
                    textBox2.Text = mem.Mem_Name;
                    List<Book_Register_Sub> dataSource = model.Book_Register_Sub.Where(s => s.Mem_Id == id && s.Br_Fine == "").ToList();
                    List<Book_Register_Sub> dataSource2 = model.Book_Register_Sub.Where(s => s.Mem_Id == id && s.Br_Fine != "").ToList();

                    List<string> obj = model.Book_Register_Sub.Where(s => s.Reg_Id == id).Select(s => s.Book_Id).ToList();
                    comboBox1.DataSource = obj;
                    dataGridView1.DataSource = dataSource2;
                    dataGridView2.DataSource = dataSource;
                }
                else
                {
                    MessageBox.Show("Member Not found");
                }


         
           

        }
        private void Book_In_Register_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void tectChanged(object sender, EventArgs e)
        {
            Book_Master book_name = model.Book_Master.Where(s => s.Book_Id == comboBox1.Text).FirstOrDefault();
            if (book_name != null)
            {

                textBox4.Text = book_name.Book_Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = model.Book_Register_Sub.Where(s => s.Mem_Id == textBox1.Text && s.Book_Id==comboBox1.Text && s.Br_Fine=="").FirstOrDefault();
            if(obj!=null)
            {

                obj.Br_Fine = textBox6.Text;
                model.SaveChanges();
                loadDataIntoDataGridView();
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MainView().Show();
            this.Hide();
        }
    }
}
