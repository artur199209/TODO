using System;
using System.Windows;

namespace TODO
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class AddTaskWindow : Window
	{
		private MainWindow mainwindow = null;

		public AddTaskWindow(MainWindow mwindow)
		{
			InitializeComponent();
			mainwindow = mwindow;
			initValueInComboBox();
		}

		private void initValueInComboBox()
		{
			foreach(var item in Enum.GetValues(typeof(Priorities.Priority)))
			{
				prioritycmbbox.Items.Add(item);
			}
		}

		public void addTask()
		{
			TODOTask todotask = new TODOTask
			{
				priority = prioritycmbbox.Text,
				task = tasktxtbox.Text,
				datetime = datepicker.Text
			};
			mainwindow.addTaskToList(todotask);
			this.Close();
		}

		private void addTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			if(prioritycmbbox.Text != "" && tasktxtbox.Text != "" && datepicker.Text != "")
			{
				addTask();
			}
			else
			{
				MessageBox.Show("Uzupełnij wszystkie pola.");
			}
		}
	}
}