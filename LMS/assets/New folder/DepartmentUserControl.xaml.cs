using System;
using System.Collections.Generic;
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

namespace PayrollManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for DepartmentUserControl.xaml
    /// </summary>
    public partial class DepartmentUserControl : UserControl
    {
        public DepartmentUserControl()
        {
            InitializeComponent();
            loadTable();
            loadDepartmentReport();
            //888888888888888888888888888
            ChartValues<double> employeeTotal = new ChartValues<double>();
            List<string> departmentName = new List<string>();
            using (var db = new PayrollDBEntities())
            {
                var query = from s in db.Employees//outer sequence
                            select s;
                List<Employee> list = query.ToList();
                var query1 = from s in db.Departments//outer sequence
                            select s;
                List<Department> departmentlist = query1.ToList();
                foreach(Department d in departmentlist)
                {
                    double count = 0;
                    foreach(Employee e in list)
                    {
                        if (e.departmentID == d.Id)
                            count++;
                    }
                    employeeTotal.Add(count);
                    departmentName.Add(d.name);
                }
                SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "No of employees",
                    Values = employeeTotal
                }
            };

                //also adding values updates and animates the chart automatically
                //  SeriesCollection[1].Values.Add(48d);

                Labels = departmentName.ToArray();
                Formatter = value => value.ToString("N");

                DataContext = this;


                var dquery = from s in db.Departments//outer sequence

                             select s;
                txbTotalDepartment.Text = "  Total Department\n  " + dquery.ToList().Count.ToString();
            }
        }

        private void btnInsertDepartment_Click(object sender, RoutedEventArgs e)
        {
            AddDepartment newDepart =new AddDepartment();
            newDepart.ShowDialog();
            loadTable();
            loadDepartmentReport();
        }

        private void btnDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            Department h = DepartmentDataGrid.SelectedItem as Department;
            //  int id = h.id;
            using (var db = new PayrollDBEntities())
            {
                Department hh = db.Departments.Where(x => x.Id == h.Id).Select(x => x).FirstOrDefault();
                db.Departments.Remove(hh);
                db.SaveChanges();
                loadTable();
                loadDepartmentReport();
            }
        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            Department h = DepartmentDataGrid.SelectedItem as Department;
            //  int id = h.id;
            EditDepartment ee = new EditDepartment(h);
            ee.ShowDialog();
            loadTable();
        }
        private void loadTable()
        {
            using (var db = new PayrollDBEntities())
            {
                var query = from a in db.Departments
                            select a;
                DepartmentDataGrid.ItemsSource = query.ToList();
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        private void loadDepartmentReport()
        {
            using (var db = new PayrollDBEntities())
            {
                var dquery = from s in db.Departments//outer sequence

                             select s;
                txbTotalDepartment.Text = "  Total Department\n  " + dquery.ToList().Count.ToString();
            }     
        }//*************
    }
}