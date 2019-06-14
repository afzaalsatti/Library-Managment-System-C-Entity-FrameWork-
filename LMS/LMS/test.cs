using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MetroFramework.Forms;

namespace LMS
{
    public partial class test : MetroForm
    {
        string t1, t2, t3;
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        public test()
        {
            
            InitializeComponent();
            LMSEntities model = new LMSEntities();









            //seller
var obj = model.Purchase_Main.Select(s => s);
            t1 = "---------------------------------------Best Sellers----------------------------------------\n";
            List<string> l = new List<string>();
            SeriesCollection SeriesCollection = new SeriesCollection();
            if (obj != null)
            {
                foreach (Purchase_Main v in obj)
                {
                    if (!l.Contains(v.Pur_Form))
                    {
                        l.Add(v.Pur_Form);
                        int count = model.Purchase_Sub.Where(s => s.Pur_Id == v.Pur_Id).Count();
                        string id = v.Pur_Form;
                        t1 = t1 + "Seller Name :" + id + "\n";
                        t1 = t1 + "   " + id + " has sold " + count + " items \n";
                        SeriesCollection.Add(new PieSeries
                        {
                            
                        Title = "Seller :"+id +" Handled Purchase ID "+v.Pur_Id+"  And Sold Items :  ",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                            DataLabels = true
                        });


                    }






                }
            }
            pieChart1.Series = SeriesCollection;
            //Purchases wrt date
            t2 = "---------------------------------------Purchase W.r.t Day----------------------------------------\n";


            var pm = model.Purchase_Main.Select(s => s);

              List<string>pml = new List<string>();
              SeriesCollection SeriesCollection2 = new SeriesCollection();
              if (pm!=null)
              {
                  foreach(Purchase_Main v in pm)
                  {
                      if(!pml.Contains(v.Pur_Date))
                      {
                        t2 += "Date :" + v.Pur_Date + "\n";
                          pml.Add(v.Pur_Date);
                          int count = model.Purchase_Main.Where(s => s.Pur_Date == v.Pur_Date).Count();
                        t2 += "Number of Purchases " + count + "\n";
                        t2 += "----------------------------------------------------------\n";

                        SeriesCollection2.Add(new PieSeries
                          {
                              Title = v.Pur_Date,
                              Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                              DataLabels = true
                          });


                      }






                  }
              }

            pieChart2.Series = SeriesCollection2;



            var sb = model.Purchase_Sub.Select(s => s);
            t3 = "---------------------------------------Sold Books----------------------------------------\n";


            List<string> sbl = new List<string>();
            SeriesCollection SeriesCollection3 = new SeriesCollection();
            if (sb != null)
            {
                foreach (Purchase_Sub v in sb)
                {
                    if (!sbl.Contains(v.Pur_Date))
                    {
                        t3 += "Date : " + v.Pur_Date + "\n";
                        sbl.Add(v.Pur_Date);
                        string title= model.Book_Master.Where(s => s.Book_Id == v.Book_Id).Select(s=>s.Book_Name).FirstOrDefault();
                        int count = model.Purchase_Sub.Where(s =>  s.Pur_Date==v.Pur_Date).Count();


                        SeriesCollection3.Add(new PieSeries
                        {
                            Title = "Books Sold : " + "  Date: "+v.Pur_Date,
                            Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                            DataLabels = true
                        });


                    }






                }
            }

            pieChart3.Series = SeriesCollection3;



            var mp = model.Purchase_Main.Select(s => s);

            List<string> mbl = new List<string>();
            SeriesCollection SeriesCollection4 = new SeriesCollection();
            if (mp != null)
            {
               
                foreach (Purchase_Main v in mp)
                {
                    double total_purchase = 0;
                    if (!mbl.Contains(v.Pur_Date))
                    {
                        sbl.Add(v.Pur_Date);
                        List<string> lis = model.Purchase_Main.Where(s=>s.Pur_Date==v.Pur_Date).Select(s => s.Pur_Amount).ToList();
                        
                        foreach (var vv in lis)
                        {
                            total_purchase = total_purchase + Convert.ToDouble(vv.Trim());

                        }
                       
                        SeriesCollection4.Add(new PieSeries
                        {
                            Title ="Purchase ID : "+ v.Pur_Id+" Amount Spend",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(total_purchase) },
                            DataLabels = true
                        });


                    }






                }
            }

            pieChart4.Series = SeriesCollection4;



            var bb = model.Book_Register_Sub.Select(s => s);

            List<string> bbl = new List<string>();
            SeriesCollection SeriesCollection5 = new SeriesCollection();
            if (bb != null)
            {
                
                foreach (Book_Register_Sub v in bb)
                {
                    if (!bbl.Contains(v.Book_Id))
                    {
                        bbl.Add(v.Book_Id);
                        List<string> lis = model.Book_Register_Sub.Where(s => s.Book_Id == v.Book_Id).Select(s => s.Br_Qty).ToList();
                       
                        double count = 0;
                        foreach (var vv in lis)
                        {
                            count = count + Convert.ToDouble(vv.Trim());

                        }
                       
                        string title = model.Book_Master.Where(s => s.Book_Id == v.Book_Id).Select(s => s.Book_Name).FirstOrDefault();

                        SeriesCollection5.Add(new PieSeries
                        {
                            Title = "Book ID : " + v.Book_Id + "Book Name"+title+" Copies:",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                            DataLabels = true
                        });


                    }






                }
            }

            pieChart5.Series = SeriesCollection5;



            var sd = model.Stocks.Select(s => s);

            List<string> sdl = new List<string>();
            SeriesCollection SeriesCollection6 = new SeriesCollection();
            if (bb != null)
            {

                foreach (Stock v in sd)
                {
                    if (!sdl.Contains(v.Book_Id))
                    {
                        sdl.Add(v.Book_Id);
string str= model.Stocks.Where(s => s.Book_Id == v.Book_Id).Select(s => s.Qty).FirstOrDefault();

                        double count = Convert.ToDouble(str.Trim());
                           string title = v.Book_Name;

                        SeriesCollection6.Add(new PieSeries
                        {
                            Title = "Book ID : " + v.Book_Id + "   Book Name  : " + title + "  Stock Remaining  :  ",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                            DataLabels = true
                        });


                    }






                }
            }

            pieChart6.Series = SeriesCollection6;




            var rev = model.Purchase_Main.Select(s => s);

            List<string> revl = new List<string>();
            SeriesCollection SeriesCollection7= new SeriesCollection();
            if (bb != null)
            {

                foreach (Purchase_Main v in rev)
                {
                    if (!revl.Contains(v.Pur_Date))
                    {
                        revl.Add(v.Pur_Date);
                        double count = 0;
                        List<string> lis = model.Purchase_Main.Where(s => s.Pur_Date == v.Pur_Date).Select(s => s.Pur_Amount).ToList();
                        
                        foreach (var vv in lis)
                        {
                            count = count + Convert.ToDouble(vv.Trim());

                        }
                       
                        string title = v.Pur_Date;

                        SeriesCollection7.Add(new PieSeries
                        {
                            Title = "Date : " + v.Pur_Date +  " Revenue  :  ",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                            DataLabels = true
                        });


                    }






                }
            }

            pieChart9.Series = SeriesCollection7;


            /* List<Stock> list = model.Stocks.Select(s => s).ToList();

             foreach (var x in list)
             {
                 Console.WriteLine("Book Stock: \n"  + " Name: " + x.Book_Name+"Stock"+x.Qty);
             }

             //total sales

             List<string> lis = model.Purchase_Main.Select(s => s.Pur_Amount).ToList();
             double total = 0;
           foreach(var v in lis)
             {
                 total = total + Convert.ToDouble(v.Trim());

             }

             MessageBox.Show("Total Sale" + total);

     */

            //





        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void test_Load(object sender, EventArgs e)
        {
           
           
        }
    }
    }

