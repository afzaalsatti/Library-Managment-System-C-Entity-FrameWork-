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

namespace LMS
{
    public partial class Book : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Book()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Book_Master.Select(s => s);

            List<Book_Master> dataSource = new List<Book_Master>();

            foreach (Book_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Book_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book_Master obj = new Book_Master();
            obj.Book_Id = textBox1.Text;
            obj.Book_Name = textBox2.Text;
            obj.Book_Auth = textBox3.Text;
            obj.Book_Edition = textBox4.Text;
            obj.Book_Publish = textBox5.Text;
            obj.Sr_Id = comboBox1.Text;
            obj.Book_Status = comboBox2.Text;
            try
            {
                model.Book_Master.Add(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Try Again");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book_Master obj = model.Book_Master.Where(s => s.Book_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox2.Text != "")
                    obj.Book_Name = textBox2.Text;

                obj.Book_Status = comboBox2.Text;
                obj.Sr_Id = comboBox1.Text;

                if (textBox3.Text != "")
                    obj.Book_Auth = textBox3.Text;
                if (textBox4.Text != "")
                    obj.Book_Edition = textBox4.Text;
                if (textBox5.Text != "")
                    obj.Book_Publish = textBox5.Text;
               
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book_Master obj = model.Book_Master.Where(s => s.Book_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Book_Master.Remove(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Book Not Found");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
           
        }

        private void Book_Load_1(object sender, EventArgs e)
        {

        }
    }
}
