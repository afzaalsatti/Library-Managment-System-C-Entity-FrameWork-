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
    public partial class Stocks : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Stocks()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Stocks.Select(s => s);

            List<Stock> dataSource = new List<Stock>();

            foreach (Stock obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Stocks_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            obj.Book_Id = comboBox2.Text;
            obj.Book_Name = textBox2.Text;
            obj.Qty = textBox3.Text;
            obj.Status = comboBox1.Text;
            
            try
            {
                model.Stocks.Add(obj);
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
            Stock obj = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
            if (obj != null)
            {
                obj.Qty = textBox3.Text;
                obj.Status = comboBox1.Text;
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }

        private void textChanged (object sender, EventArgs e)
        {
            Book_Master book_name = model.Book_Master.Where(s =>s.Book_Id==comboBox2.Text).FirstOrDefault();
            if(book_name != null)
            {
               
                textBox2.Text = book_name.Book_Name;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Stock obj = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Stocks.Remove(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Book Stock Not Found");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }
    }
}
