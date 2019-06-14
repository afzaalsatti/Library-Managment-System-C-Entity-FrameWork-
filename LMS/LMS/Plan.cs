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
    public partial class Plan : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Plan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Plan_Master obj = new Plan_Master();
            obj.Plan_Id=textBox1.Text;
            obj.Plan_Name=textBox8.Text;
            obj.Plan_Status= comboBox1.Text;
            obj.Plan_Validity=textBox5.Text;
            obj.Plan_Amount= textBox4.Text;
            obj.Plan_Book_Limit=textBox7.Text;
            obj.Plan_Book_Hold = textBox6.Text;
            try
            {
                model.Plan_Master.Add(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Input Try Again");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Plan_Load(object sender, EventArgs e)
        {
           
            List<string> list = new List<string>();
            list.Add("Active");
            list.Add("InActive");
            comboBox1.DataSource = list;
            loadDataIntoDataGridView();
    }


        private void loadDataIntoDataGridView()
        {
            var data = model.Plan_Master.Select(s => s);

            List<Plan_Master> dataSource = new List<Plan_Master>();

            foreach (Plan_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plan_Master obj = model.Plan_Master.Where(s => s.Plan_Id == textBox1.Text).FirstOrDefault();
            if(obj!=null)
            {
                if (textBox8.Text!="")
                obj.Plan_Name = textBox8.Text;

                obj.Plan_Status = comboBox1.Text;

                if (textBox5.Text != "")
                    obj.Plan_Validity = textBox5.Text;
                if (textBox4.Text != "")
                    obj.Plan_Amount = textBox4.Text;
                if (textBox7.Text != "")
                    obj.Plan_Book_Limit = textBox7.Text;
                if (textBox6.Text != "")
                    obj.Plan_Book_Hold = textBox6.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {

            Plan_Master obj = model.Plan_Master.Where(s => s.Plan_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Plan_Master.Remove(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }
    }
}
