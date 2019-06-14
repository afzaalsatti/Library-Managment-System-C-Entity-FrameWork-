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
    public partial class Section : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public Section()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            var data = model.Section_Master.Select(s => s);

            List<Section_Master> dataSource = new List<Section_Master>();

            foreach (Section_Master obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Section_Master obj = new Section_Master();
            obj.Sec_Id = textBox1.Text;
            obj.Sec_Name = textBox2.Text;
            obj.Sec_Status = comboBox1.Text;
         
            try
            {
                model.Section_Master.Add(obj);
                model.SaveChanges();
                loadDataIntoDataGridView();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input Try Again");
            }
            
        }

        private void Section_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Availble");
            list.Add("Un Availble");
            comboBox1.DataSource = list;
            loadDataIntoDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Section_Master obj = model.Section_Master.Where(s => s.Sec_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                if (textBox2.Text != "")
                    obj.Sec_Name = textBox2.Text;

                obj.Sec_Status = comboBox1.Text;

              
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
            Section_Master obj = model.Section_Master.Where(s => s.Sec_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Section_Master.Remove(obj);
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
