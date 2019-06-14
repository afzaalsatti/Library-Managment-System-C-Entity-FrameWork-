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
    /// Interaction logic for HolidayUserControl.xaml
    /// </summary>
    public partial class HolidayUserControl : UserControl
    {
        private int totalSundays;
        public HolidayUserControl()
        {
            InitializeComponent();
            loadTable();
            
            //   HolidayDataGrid.RowsAdd(); 

            //Program to load total no of sundays in current year
            totalSundays = CountSundays(new DateTime(DateTime.Now.Year,1,1), new DateTime(DateTime.Now.Year, 12, 31));
            txbTotalSundayInYear.Text = "  Total Sundays\n  "+totalSundays;
            loadHolidayReports();

        }
        //public Func<ChartPoint, string> PointLabel { get; set; }

 /*       private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
    {
        var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

        //clear selected slice.
        foreach (PieSeries series in chart.Series)
            series.PushOut = 0;

        var selectedSeries = (PieSeries)chartpoint.SeriesView;
        selectedSeries.PushOut = 8;
    }
    */
    private void btnInsertHoliday_Click(object sender, RoutedEventArgs e)
        {
           // cw.ShowInTaskbar = false;
//cw.Owner = Application.Current.MainWindow;
            AddHoliday holday =new  AddHoliday();
            holday.ShowDialog();

            /************************
             Refresh Table code heere*/
            loadTable();
            loadHolidayReports();
            ////////////////////////
        }
        private void loadTable()
        {
            using (var db = new PayrollDBEntities())
            {
                var query = from a in db.Holidays
                            select a;
                HolidayDataGrid.ItemsSource = query.ToList();
            }
        }

        private void btnDeleteHoliday_Click(object sender, RoutedEventArgs e)
        {
            Holiday h = HolidayDataGrid.SelectedItem as Holiday;
          //  int id = h.id;
            using (var db = new PayrollDBEntities())
            {
                Holiday hh = db.Holidays.Where(x => x.id == h.id).Select(x => x).FirstOrDefault();
                db.Holidays.Remove(hh);
                db.SaveChanges();
                loadTable();
                loadHolidayReports();
            }
        }

        private void btnEditHoliday_Click(object sender, RoutedEventArgs e)
        {
            Holiday h = HolidayDataGrid.SelectedItem as Holiday;
            //  int id = h.id;
            EditHoliday ee = new EditHoliday(h);
            ee.ShowDialog();
            loadTable();
        }


        private int CountSundays(DateTime startDate, DateTime endDate)
        {
            int weekEndCount = 0;
            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }
            TimeSpan diff = endDate - startDate;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekEndCount += 1;
                }
            }
            return weekEndCount;
        }
        private  void loadHolidayReports()
        {
            int totalHolidayEvents;
            using (var db = new PayrollDBEntities())
            {
                var query = from a in db.Holidays
                            select a;
                totalHolidayEvents = query.ToList().Count;
                txbTotalHoldays.Text = "  Total Events\n  " + totalHolidayEvents;
                //888888888888888888888888888888888888888888888888

                // initailizing guage
                int totalDaysInYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
                Guage.To = totalDaysInYear;

                Guage.Value = totalDaysInYear - (this.totalSundays + totalHolidayEvents);
            }
        }
    }
}