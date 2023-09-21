using prog6212_task_1.Models;
using prog6212_task_1.Windows;
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
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            // Is there an error?
            bool is_error = false;

            // Reset error string
            errorTextBlock.Text = "";

            // Get date from datepicker
            var date = startDatePicker.SelectedDate;

            // Get number of weeks from textbox
            var num_of_weeks_str = numWeeksTextbox.Text;


            // Validate the inputs
            if (date == null)
            {
                errorTextBlock.Text += "The start date for the semester is invalid! ";
                is_error = true;
            }

            int num_of_weeks = 0;
            try
            {
                num_of_weeks = Int32.Parse(num_of_weeks_str);
            }
            catch (FormatException)
            {
                errorTextBlock.Text += "The number of weeks in the semester is invalid! ";
                is_error = true;
            }


            if(!is_error) // If there are no errors
            {
                // Launch next window
                /*ModulesWindow win = new ModulesWindow(num_of_weeks);
                win.Show();
                this.Close();*/
            }
        }
    }
}
