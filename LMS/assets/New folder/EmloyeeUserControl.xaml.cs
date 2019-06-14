using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace PayrollManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for EmloyeeUserControl.xaml
    /// </summary>
    public partial class EmloyeeUserControl : UserControl
    {
        public EmloyeeUserControl()
        {
            InitializeComponent();
            loadTable();

        }

        private void btnInsertEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee window = new AddEmployee();
            window.ShowDialog();

            /************************
             Refresh Table code heere*/
            loadTable();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView h = EmployeeDataGrid.SelectedItem as EmployeeView;
            //  int id = h.id;
            EditEmploy ee = new EditEmploy(h.Id); ;
            ee.ShowDialog();
            loadTable();
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView h = EmployeeDataGrid.SelectedItem as EmployeeView;
            //  int id = h.id;
            using (var db = new PayrollDBEntities())
            {
                Employee hh = db.Employees.Where(x => x.Id == h.Id).Select(x => x).FirstOrDefault();
                db.Employees.Remove(hh);
                db.SaveChanges();
                loadTable();
            }
        }
        private void loadTable()
        {
            ShowDetailGrid.Visibility = System.Windows.Visibility.Hidden;
            List<EmployeeView> list = new List<EmployeeView>();
            using (var db = new PayrollDBEntities())
            {

                var AllEmployees = db.Employees;

                foreach (var pp in AllEmployees)
                {
                    list.Add(new EmployeeView() { Id = pp.Id, image = pp.image, name = pp.name, salary = pp.salary });

                }
                EmployeeDataGrid.ItemsSource = list;

            }


            //  DTGridEmp.ItemsSource = items;
            /*    var query = from a in db.Employees
                            select a;
                EmployeeDataGrid.ItemsSource = query.ToList();*/
        }//*********************
        class EmployeeView
        {
            public int Id { get; set; }
            public byte[] image { get; set; }
            public string name { get; set; }
            public int salary { get; set; }

        }


      //  public SeriesCollection SeriesCollection { get; set; }

        private void ShowRow(object sender, RoutedEventArgs e)
        {
            ShowDetailGrid.Visibility = System.Windows.Visibility.Visible;
            EmployeeView h = EmployeeDataGrid.SelectedItem as EmployeeView;
            using (var db = new PayrollDBEntities())
            {
                var query = from ee in db.Employees
                            where ee.Id == h.Id
                            select ee;
                Employee user = query.First();

                lblEmployeeID.Content = "EmployeeID :  " + user.Id;
                lblName.Content = "Name :  " + user.name;
                lblFatherName.Content = "Father name :  " + user.fatherName;
                lblMartialStatus.Content = "MartialStatus :  " + user.martialStatus;
               
                lblDepartmentID.Content = "DepartmentID :  " + user.departmentID;
                lblSalary.Content = "Salary :  " + user.salary;
                lblBirthdate.Content = "Birthdate :  " + user.birthdate.ToLongDateString();
                lblCNIC.Content = "CNIC :  " + user.cnic;
                //*********************************
                //***************************

                //***********************************

                var department = db.Departments.Where(x => x.Id == user.departmentID).Select(x => x).FirstOrDefault();
                lblDepartmentName.Content = "Department Name :  " + department.name;

                imageBox.Source = GetBitmapImageFromBytes(user.image);

                int AGE = DateTime.Now.Year - user.birthdate.Year;
                txbAge.Text = "  Current Age\n  " + (AGE);
                txbRetirementDays.Text = "  Retirement in\n  " + (60-AGE);

               /* var OntimeQuery = from ee in db.Attendances
                                  where ee.employid == user.Id && ee.status.Equals("on time")
                                  select ee;*/
                var leaveQuery = from ee in db.Leaves
                                  where ee.employeeID == user.Id
                                  select ee;
                txbTotalLeave.Text = "Total Leave :  " + leaveQuery.ToList().Count;
                var LateQuery = from ee in db.Attendances
                                where ee.employid == user.Id && ee.status.Equals("late")
                                select ee;
               txbTotalLate.Text = "Total Late :  " + LateQuery.ToList().Count;


                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            }

        }
        private BitmapImage GetBitmapImageFromBytes(byte[] bytes)
        {
            BitmapImage btm;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                btm = new BitmapImage();
                btm.BeginInit();
                btm.StreamSource = ms;
                // Below code for caching is crucial.
                btm.CacheOption = BitmapCacheOption.OnLoad;
                btm.EndInit();
                btm.Freeze();
            }
            return btm;
        }

        private void PrintSlip(object sender, RoutedEventArgs e)
        {
            EmployeeView h = EmployeeDataGrid.SelectedItem as EmployeeView;
            PrintPreview pt = new PrintPreview(h.Id);
            pt.Show();
        }
        

    }
}
