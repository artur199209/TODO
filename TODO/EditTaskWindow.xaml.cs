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
using System.Windows.Shapes;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for EditTaskWindow.xaml
	/// </summary>
	public partial class EditTaskWindow : Window
	{
		private MainWindow mainwindow = null;
		TODOTask tasktoremove = null;

		public EditTaskWindow(MainWindow mwindow, TODOTask todotask)
		{
			InitializeComponent();
			mainwindow = mwindow;
			tasktoremove = todotask;
			taskTxtBox.Text = todotask.task;
			datepicker.Text = todotask.datetime;
		}

		private void editTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			if(taskTxtBox.Text != "" && prioritycmbbox.Text != "")
			{
				mainwindow.removeTaskFromList(tasktoremove);
				TODOTask editedTask = new TODOTask();
				editedTask.task = taskTxtBox.Text;
				editedTask.priority = prioritycmbbox.Text;
				editedTask.datetime = datepicker.Text;
				mainwindow.addTaskToList(editedTask);
				this.Close();
			}
			else
			{
				MessageBox.Show("Uzupełnij wszystkie pola.");
			}
		}
	}
}
