using prog6212_task_1.Models;
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

namespace prog6212_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Module module = new Module("prog6212", "Programming 2B", 23, 10, 14);
            module.setHoursStudied(1, DateOnly.FromDateTime(DateTime.Now));
/*          module.setHoursStudied(7, new DateOnly(2023, 9, 20));
            module.setHoursStudied(5, new DateOnly(2023, 9, 17));
            module.setHoursStudied(4, new DateOnly(2023, 9, 18));
            module.setHoursStudied(7, new DateOnly(2023, 9, 24));
            module.setHoursStudied(8, new DateOnly(2023, 9, 20));
            module.setHoursStudied(10, new DateOnly(2023, 9, 25));*/
            int hours = module.getHoursStudiedThisWeek();
            int rem = module.getRemainingSelfStudyHoursThisWeek();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            // Reset error string
            errorTextBlock.Text = "";

            // Get date from datepicker
            var date = startDatePicker.SelectedDate;
            
            if(date == null)
            {
                errorTextBlock.Text += "The start date for the semester is invalid! ";
            }


            // Get number of weeks from textbox
            int num_of_weeks;
            var num_of_weeks_str = numWeeksTextbox.Text;
            try
            {
                num_of_weeks = Int32.Parse(num_of_weeks_str);
            }
            catch (FormatException)
            {
                errorTextBlock.Text += "The number of weeks in the semester is invalid! ";
            }

        }
    }
}
