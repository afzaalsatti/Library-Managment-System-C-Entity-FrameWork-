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
    public partial class Member_Transaction : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Member_Transaction()
        {
            InitializeComponent();
        }

        private void loadDataIntoDataGridView()
        {
            var data = model.Mem_Transaction.Select(s => s);

            List<Mem_Transaction> dataSource = new List<Mem_Transaction>();

            foreach (Mem_Transaction obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Member_Transaction_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool mem = model.Member_Master.Select(s => s.Mem_Id == textBox2.Text).FirstOrDefault();
            if(mem)
            {
                Mem_Transaction obj = new Mem_Transaction();
                obj.Trans_Id = textBox1.Text;
                obj.Mem_Id = textBox2.Text;
                obj.Mem_Name = textBox3.Text;
                obj.Trans_Date = dateTimePicker1.Text;
                obj.Amount = textBox4.Text;
                obj.Type = comboBox1.Text;
                obj.Fine = textBox5.Text;
                obj.Status = comboBox2.Text;
                try
                {
                    model.Mem_Transaction.Add(obj);
                    model.SaveChanges();
                    loadDataIntoDataGridView();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Input Try Again");
                }

            }
            else
            {
                MessageBox.Show("Enter Valid Member ID");
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mem_Transaction obj = model.Mem_Transaction.Where(s => s.Trans_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox3.Text != "")
                    obj.Mem_Name = textBox3.Text;

                obj.Trans_Date = dateTimePicker1.Text;
                obj.Amount = textBox4.Text;
                obj.Type = comboBox1.Text;
                obj.Status = comboBox2.Text;

                model.SaveChanges();
                loadDataIntoDataGridView();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Mem_Transaction obj = model.Mem_Transaction.Where(s => s.Trans_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Mem_Transaction.Remove(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } }
