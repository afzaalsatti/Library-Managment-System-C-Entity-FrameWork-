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
using MetroFramework.Forms;

namespace LMS
{
    public partial class Purchase : MetroForm
    {
        static int count = 0;
        LMSEntities model = new LMSEntities();
        public Purchase()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {
            string text = textBox1.Text;
            List<Purchase_Sub> dataSource = null;
           dataSource = model.Purchase_Sub.Where(s => s.Pur_Id == text).ToList();

           dataGridView1.DataSource = dataSource;
        }
        private void Purchase_Load(object sender, EventArgs e)
        {

        }

        private void textChanged(object sender, EventArgs e)
        {


            
            Book_Master book_name = model.Book_Master.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
            if (book_name != null)
            {

                textBox4.Text = book_name.Book_Name;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            loadDataIntoDataGridView();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Stock book = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
            if (book != null && (Convert.ToInt32(book.Qty.Trim()) > Convert.ToInt32(textBox5.Text.Trim())))
            {

                Purchase_Sub obj = model.Purchase_Sub.Where(s => s.Pur_Id == textBox1.Text).FirstOrDefault();
                if (obj != null)
                {
                    book.Qty = (Convert.ToInt32(book.Qty) - Convert.ToInt32(textBox5.Text) + "");
                    model.SaveChanges();
                    obj.Book_Id = comboBox2.Text;
                    obj.Book_Name = textBox4.Text;
                    obj.Qty = textBox5.Text;
                    obj.Rate = textBox6.Text;
                    obj.Amount = textBox7.Text;
                    obj.Status = comboBox1.Text;
                    model.SaveChanges();
                    loadDataIntoDataGridView();



                }
                else
                {
                    MessageBox.Show("Plan Not Found");

                }
            }
            else
            {
                MessageBox.Show("Request Quantity not availble");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {

            Purchase_Sub obj = model.Purchase_Sub.Where(s => s.Pur_Id == textBox1.Text).FirstOrDefault();
            if (obj != null)
            {
                model.Purchase_Sub.Remove(obj);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Book_Master book_name = model.Book_Master.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
                if (book_name != null)
                {

                    textBox4.Text = book_name.Book_Name;
                }
                count = model.Purchase_Sub.Where(s => s.Pur_Id == textBox1.Text).ToList().Count();

                if (count == 0)
                {
                    var obj = model.Purchase_Main.Where(s => s.Pur_Id == textBox1.Text).FirstOrDefault();
                    if (obj == null)
                    {
                        Purchase_Main pur = new Purchase_Main();
                        pur.Pur_Id = textBox1.Text;
                        pur.Pur_Date = dateTimePicker1.Text;
                        pur.Pur_Form = textBox2.Text;


                        pur.Pur_Amount = textBox7.Text;
                        pur.Pur_Status = comboBox1.Text;
                        model.Purchase_Main.Add(pur);
                    }


                }

                Stock book = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
                if (book != null && (Convert.ToInt32(book.Qty.Trim()) > Convert.ToInt32(textBox5.Text.Trim())))
                {
                    Purchase_Main pur = new Purchase_Main();
                    pur = model.Purchase_Main.Where(s => s.Pur_Id == textBox1.Text).FirstOrDefault();
                    if (pur != null)
                    {
                        pur.Pur_Amount = (Convert.ToDouble(pur.Pur_Amount) + Convert.ToDouble(textBox7.Text)).ToString();
                    }
                    Purchase_Sub obj = new Purchase_Sub();
                    obj.Pur_Id = textBox1.Text;
                    obj.Pur_Date = dateTimePicker1.Text;
                    obj.Pur_No = count.ToString();
                    obj.Book_Id = comboBox2.Text;
                    obj.Book_Name = textBox4.Text;
                    obj.Qty = textBox5.Text;
                    obj.Rate = textBox6.Text;
                    obj.Amount = textBox7.Text;
                    obj.Status = comboBox1.Text;



                    try
                    {
                        book.Qty = (Convert.ToInt32(book.Qty) - Convert.ToInt32(textBox5.Text) + "");
                        model.SaveChanges();
                        model.Purchase_Sub.Add(obj);
                        model.SaveChanges();
                        loadDataIntoDataGridView();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Invalid Input Try Again" + exp);
                    }
                }
                else
                {
                    MessageBox.Show("Request Quantity not availble");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Recheck Inputs");
            }
           
                


           
        }
    }
}
