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
    public partial class Rack : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Rack()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rack_Master obj = model.Rack_Master.Where(s => s.Rack_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Rack_Master.Remove(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rack_Master obj = model.Rack_Master.Where(s => s.Rack_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox2.Text != "")
                    obj.Rack_Name = textBox2.Text;

                obj.Rack_Status = comboBox1.Text;


                model.SaveChanges();
                loadDataIntoDataGridView();



            }
            else
            {
                MessageBox.Show("Plan Not Found");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rack_Master obj = new Rack_Master();
            obj.Rack_Id = textBox1.Text;
            obj.Rack_Name = textBox2.Text;
            obj.Rack_Status = comboBox1.Text;

            try
            {
                model.Rack_Master.Add(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Try Again");
            }
        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Rack_Master.Select(s => s);

            List<Rack_Master> dataSource = new List<Rack_Master>();

            foreach (Rack_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void Rack_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Availble");
            list.Add("Un Availble");
            comboBox1.DataSource = list;
            loadDataIntoDataGridView();

        }
    }
}
