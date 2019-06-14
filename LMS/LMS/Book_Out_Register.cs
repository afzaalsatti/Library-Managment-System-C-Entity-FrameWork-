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
    public partial class Book_Out_Register : MetroForm
    {
        static int count = 0;
        LMSEntities model = new LMSEntities();
        public Book_Out_Register()
        {
            InitializeComponent();
        }
        private void loadDataIntoDataGridView()
        {


            List<Book_Register_Sub> dataSource = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).ToList();
            Book_Register_Main obj = model.Book_Register_Main.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();
            if(obj!=null)
            {
                textBox2.Text = obj.Mem_id;
                comboBox1.Text = obj.Reg_Status;
            }
            dataGridView1.DataSource = dataSource;

        }
        private void Book_Out_Register_Load(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void textChanged(object sender, EventArgs e)
        {
            Book_Master book_name = model.Book_Master.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
            if (book_name != null)
            {

                textBox4.Text = book_name.Book_Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try { 
           
                
           
            string id = model.Member_Master.Where(s => s.Mem_Id == textBox2.Text).Select(s => s.Plan_Id).FirstOrDefault();
            string limit=null,hold=null;
            double total_books_out = 0;
            if (id!=null)
            {
                limit= model.Plan_Master.Where(p => p.Plan_Id == id).Select(p => p.Plan_Book_Limit +"-"+p.Plan_Book_Hold).FirstOrDefault();
                if(limit!=null)
                {
                    hold = limit.Substring(limit.IndexOf("-")+1);
                    limit = limit.Substring(0, limit.IndexOf("-"));


                    IList < string > ll = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).Select(s => s.Br_Qty).ToList();
                    if(ll!=null)
                    {
                        foreach(string amount in ll)
                        {
                            total_books_out = total_books_out + Convert.ToDouble(amount);
                        }
                    }
                   
                }
                
            }

            if(limit !=null && hold!=null)
            {
                if(Convert.ToInt32(limit)>total_books_out)
                {
                    if (Convert.ToInt32(hold) > Convert.ToInt32(textBox5.Text.Trim()))
                    {

                        count = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).ToList().Count();
                            Book_Register_Main pur;
                          
                           
                            if (count == 0)
                        {
                           pur= new Book_Register_Main();
                            pur.Reg_Id = textBox1.Text;
                            pur.Mem_id = textBox2.Text;
                            pur.Reg_Status = comboBox1.Text;

                            pur.Reg_Date = dateTimePicker1.Text;

                            model.Book_Register_Main.Add(pur);
                            model.SaveChanges();

                        }

                        Stock book = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
                            pur = model.Book_Register_Main.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();
                            if(pur.Reg_Status!= "Blocked")
                            {


                                if (book != null && (Convert.ToInt32(book.Qty.Trim()) > Convert.ToInt32(textBox5.Text.Trim())))
                                {



                                    Book_Register_Sub obj = new Book_Register_Sub();
                                    obj.Reg_Id = textBox1.Text;
                                    obj.Reg_Date = dateTimePicker1.Text;
                                    obj.Mem_Id = textBox2.Text;
                                    obj.Brs_No = count.ToString();
                                    obj.Book_Id = comboBox2.Text;
                                    obj.BrOutDate = dateTimePicker2.Text;
                                    obj.BrInDate = dateTimePicker3.Text;
                                    obj.Br_Qty = textBox5.Text;
                                    obj.Br_Fine = "";
                                    obj.Br_Status = comboBox1.Text;



                                    try
                                    {
                                        book.Qty = (Convert.ToInt32(book.Qty) - Convert.ToInt32(textBox5.Text) + "");
                                        model.SaveChanges();
                                        model.Book_Register_Sub.Add(obj);
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
                            else
                            {
                                MessageBox.Show("Members Registeration is blocked");
                            }
                            

                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to lend... Update Check Your Plan");
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to lend... You have Used Your Plan");
                }

            }
            else
            {
                MessageBox.Show("Kindly Recheck Member ID");
            }
            }
            catch(Exception )
            {
                MessageBox.Show("Kindly fill All fields and Try Again");
            }
            

            /**

                        count = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).ToList().Count();

                        if (count == 0)
                        {
                            Book_Register_Main pur = new Book_Register_Main();
                            pur.Reg_Id = textBox1.Text;
                            pur.Mem_id = textBox2.Text;
                            pur.Reg_Status = comboBox1.Text;

                            pur.Reg_Date = dateTimePicker1.Text;

                            model.Book_Register_Main.Add(pur);

                        }

                        Stock book = model.Stocks.Where(s => s.Book_Id == comboBox2.Text).FirstOrDefault();
                        if (book != null && (Convert.ToInt32(book.Qty.Trim()) > Convert.ToInt32(textBox5.Text.Trim())))
                        {
                            Book_Register_Main pur = new Book_Register_Main();
                            pur = model.Book_Register_Main.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();

                            Book_Register_Sub obj = new Book_Register_Sub();
                            obj.Reg_Id = textBox1.Text;
                            obj.Reg_Date = dateTimePicker1.Text;
                            obj.Mem_Id = textBox2.Text;
                            obj.Brs_No = count.ToString();
                            obj.Book_Id = comboBox2.Text;
                            obj.BrOutDate = dateTimePicker2.Text;
                            obj.BrInDate = dateTimePicker3.Text;
                            obj.Br_Qty = textBox5.Text;
                            obj.Br_Fine = "";
                            obj.Br_Status = comboBox1.Text;



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
                        }**/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadDataIntoDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book_Register_Sub dataSource = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();
            if (dataSource != null)
            {
                model.Book_Register_Sub.Remove(dataSource);
                model.SaveChanges();
                Book_Register_Main obj = model.Book_Register_Main.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();
                if (obj != null)
                {
                    model.Book_Register_Main.Remove(obj);
                    model.SaveChanges();
                }

                loadDataIntoDataGridView();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book_Register_Sub dataSource = model.Book_Register_Sub.Where(s => s.Reg_Id == textBox1.Text).FirstOrDefault();
            if (dataSource != null)
            {
                dataSource.Br_Status = comboBox1.Text;

                model.SaveChanges();
                loadDataIntoDataGridView();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string id = model.Member_Master.Where(s => s.Mem_Id == textBox2.Text).Select(s => s.Plan_Id).FirstOrDefault();
                if (id != null)
                {
                    Book_Register_Main pur = new Book_Register_Main();
                    pur.Reg_Id = textBox1.Text;
                    pur.Mem_id = textBox2.Text;
                    pur.Reg_Status = comboBox1.Text;

                    pur.Reg_Date = dateTimePicker1.Text;

                    model.Book_Register_Main.Add(pur);
                    model.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Error in Member ID is not Valid...");
                }
                
            }
            catch(Exception )
            {

                MessageBox.Show("Error in Adding Registration");

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}