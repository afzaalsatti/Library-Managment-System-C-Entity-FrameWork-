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
    public partial class Role : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Role()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Role_Master.Select(s => s);

            List<Role_Master> dataSource = new List<Role_Master>();

            foreach (Role_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Role_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Active");
            list.Add("Suspended");
            list.Add("Blocked");
            comboBox1.DataSource = list;
            loadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role_Master obj = new Role_Master();
            obj.Role_ID = textBox1.Text;
            obj.Role = textBox2.Text;
           
            obj.Role_Status = comboBox1.Text;
            try
            {
                model.Role_Master.Add(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Invalid Input Try Again"+exp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var obj = model.Role_Master.Where(s => s.Role_ID == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox2.Text != "")
                    obj.Role = textBox2.Text;

                obj.Role_Status = comboBox1.Text;

              
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var obj = model.Role_Master.Where(s => s.Role_ID == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Role_Master.Remove(obj);
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
    }
}
