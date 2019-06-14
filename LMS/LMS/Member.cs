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
    public partial class Member : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Member()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Member_Master.Select(s => s);

            List<Member_Master> dataSource = new List<Member_Master>();

            foreach (Member_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Member_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Member_Master obj = new Member_Master();
            obj.Mem_Id = textBox1.Text;
            obj.Mem_Name = textBox8.Text;
            obj.Mem_Dob = dateTimePicker1.Text;
            obj.Mem_Doj = dateTimePicker2.Text;
            obj.Mem_Address = textBox6.Text;
            obj.Mem_Email = textBox5.Text;
            obj.Mem_Mobile = textBox4.Text;
            obj.Plan_Id=comboBox1.Text;
            obj.Mem_Status= comboBox2.Text;
            try
            {
                model.Member_Master.Add(obj);
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
            Member_Master obj = model.Member_Master.Where(s => s.Mem_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox8.Text != "")
                    obj.Mem_Name = textBox8.Text;

                obj.Plan_Id = comboBox1.Text;
                obj.Mem_Status = comboBox2.Text;

                if (dateTimePicker1.Text != "")
                    obj.Mem_Dob = dateTimePicker1.Text;
                if (dateTimePicker2.Text != "")
                    obj.Mem_Doj = dateTimePicker2.Text;

                if (textBox6.Text != "")
                    obj.Mem_Address = textBox6.Text;

                if (textBox5.Text != "")
                    obj.Mem_Email = textBox5.Text;

                if (textBox4.Text != "")
                    obj.Mem_Mobile = textBox4.Text;
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
            Member_Master obj = model.Member_Master.Where(s => s.Mem_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Member_Master.Remove(obj);
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
