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
    public partial class SecRacMap : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public SecRacMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sec_Rac_Map obj = new Sec_Rac_Map();
            obj.Sr_ID = textBox1.Text;
            obj.Rack_ID = comboBox1.Text.Substring(0, comboBox1.Text.IndexOf("-"));
            obj.Sec_ID = comboBox2.Text.Substring(0, comboBox2.Text.IndexOf("-"));
            obj.Sr_Status = comboBox3.Text;

            try
            {
                model.Sec_Rac_Map.Add(obj);
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
            var data = model.Sec_Rac_Map.Select(s => s);

            List<Sec_Rac_Map> dataSource = new List<Sec_Rac_Map>();

            foreach (Sec_Rac_Map obj in data)
            {
                dataSource.Add(obj);
            }
            dataGridView1.DataSource = dataSource;
        }
        private void SecRacMap_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sec_Rac_Map obj = model.Sec_Rac_Map.Where(s => s.Sr_ID == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {

                obj.Rack_ID = comboBox1.Text.Substring(0, comboBox1.Text.IndexOf("-"));
                obj.Sec_ID = comboBox2.Text.Substring(0, comboBox2.Text.IndexOf("-"));


                
                    obj.Sr_Status = comboBox3.Text;
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
            Sec_Rac_Map obj = model.Sec_Rac_Map.Where(s => s.Sr_ID == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Sec_Rac_Map.Remove(obj);
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
