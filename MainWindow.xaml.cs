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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_hw_four
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> tasks = new List<Task>();
        private ObservableCollection<CheckBox> checkBoxes = new ObservableCollection<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
            tasksListBox.ItemsSource = checkBoxes;
        }

        private void TasksToCheckboxes()
        {
            checkBoxes.Clear();
            foreach (var task in tasks)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = task;
                checkBoxes.Add(checkBox);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(taskTextBox.Text) && !string.IsNullOrEmpty(deadlineDatePicker.Text) && !string.IsNullOrEmpty(stateComboBox.Text))
            {
                tasks.Add(new Task(taskTextBox.Text, DateTime.ParseExact(deadlineDatePicker.Text, "yyyy-MM-dd", null), (States)stateComboBox.SelectedIndex));
                TasksToCheckboxes();
                int all = 0, active = 0, done = 0;
                foreach (var task in tasks)
                {
                    if (task.State == States.ALL)
                    {
                        all++;
                    }
                    else if (task.State == States.ACTIVE)
                    {
                        active++;
                    }
                    else
                    {
                        done++;
                    }
                    all += active + done;
                }
                allText.Text = $"All: {all}";
                activeText.Text = $"Active: {active}";
                doneText.Text = $"Done: {done}";
                taskTextBox.Text = string.Empty;
                deadlineDatePicker.Text = string.Empty;
                stateComboBox.SelectedIndex = 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tasks.OrderBy(t => t.TaskText);
            TasksToCheckboxes();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tasks.OrderByDescending(t => t.TaskText);
            TasksToCheckboxes();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tasks.OrderBy(t => t.TaskDeadline);
            TasksToCheckboxes();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tasks.OrderByDescending(t => t.TaskDeadline);
            TasksToCheckboxes();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (checkBoxes[i].IsChecked == true)
                {
                    tasks.RemoveAt(i);
                    i--;
                }
            }
            TasksToCheckboxes();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tasks.Clear();
            TasksToCheckboxes();
        }
    }
}
