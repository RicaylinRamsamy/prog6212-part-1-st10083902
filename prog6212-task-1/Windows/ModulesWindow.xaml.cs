using prog6212_task_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace prog6212_task_1.Windows
{
    /// <summary>
    /// Interaction logic for ModulesWindow.xaml
    /// </summary>
    public partial class ModulesWindow : Window
    {
        // Hold all modules
        private ObservableCollection<Module> modules;
        // Number of weeks in semester
        int semester_num_of_weeks;

        public ModulesWindow(int semester_num_of_weeks)
        {
            InitializeComponent();
            this.semester_num_of_weeks = semester_num_of_weeks;
            modules = new ObservableCollection<Module>();

            // Add some default modules for demo
            Module module = new Module("prog6212", "Programming 2B", 23, 10, semester_num_of_weeks);
            module.setHoursStudied(1, DateOnly.FromDateTime(DateTime.Now));
            Module module1 = new Module("prog7312", "Programming 3A", 21, 10, semester_num_of_weeks);
            modules.Add(module);
            modules.Add(module1);

            // Set the source of some ui components
            modulesListView.ItemsSource = modules;
            moduleComboBox.ItemsSource = modules;
        }

        // When the button is pressed to add a module
        private void addModuleButton_Click(object sender, RoutedEventArgs e)
        {

            // Reset errors
            moduleErrorTextBlock.Text = "";
            bool isError = false;

            // Get the values
            string moduleCode = moduleCodeTextBox.Text;
            string moduleName = moduleNameTextBox.Text;
            string numOfCreditsStr = numCreditsTextBox.Text;
            string classHoursPerWeekStr = classHoursTextBox.Text;

            // Do validation on the values
            if(String.IsNullOrEmpty(moduleCode))
            {
                isError= true;
                moduleErrorTextBlock.Text += "The module code entered is invalid! ";
            }

            if (String.IsNullOrEmpty(moduleName))
            {
                isError = true;
                moduleErrorTextBlock.Text += "The module name entered is invalid! ";
            }

            int numOfCredits = 0;
            try
            {
                numOfCredits = Int32.Parse(numOfCreditsStr);
            }
            catch (FormatException)
            {
                moduleErrorTextBlock.Text += "The number of credits entered is invalid! ";
                isError = true;
            }

            int classHoursPerWeek = 0;
            try
            {
                classHoursPerWeek = Int32.Parse(classHoursPerWeekStr);
            }
            catch (FormatException)
            {
                moduleErrorTextBlock.Text += "The number of credits entered is invalid! ";
                isError = true;
            }

            // If there wasnt an error, add to list
            if(!isError)
            {
                Module module = new Module(moduleCode, moduleName, numOfCredits, classHoursPerWeek, semester_num_of_weeks);
                modules.Add(module);
            }

        }

        // If the button was pressed to add studying hours
        private void addHoursButton_Click(object sender, RoutedEventArgs e)
        {

            // Reset errors
            hoursErrorTextBlock.Text = "";
            bool isError = false;


            // Do validation and get values
            string selectedModuleCode = "";
            if(moduleComboBox.SelectedItem == null)
            {
                isError= true;
            }
            else
            {
                selectedModuleCode= moduleComboBox.SelectedItem.ToString();
            }
            string hoursStudiedTodayStr = hoursTextBox.Text;

            int hoursStudiedToday = 0;
            try
            {
                hoursStudiedToday = Int32.Parse(hoursStudiedTodayStr);
            }
            catch (FormatException)
            {
                moduleErrorTextBlock.Text += "The number of hours studied today is invalid! ";
                isError = true;
            }

            if (String.IsNullOrEmpty(selectedModuleCode))
            {
                moduleErrorTextBlock.Text += "The module selected is invalid! ";
                isError = true;
            }

            // If there wasnt an error
            if(!isError)
            {
                // Use linq to find the module
                Module matching = modules.FirstOrDefault(u => u.code == selectedModuleCode);
                if(matching != null)
                {
                    matching.setHoursStudied(hoursStudiedToday, DateOnly.FromDateTime(DateTime.Now));
                }
            }
        }
    }
}
