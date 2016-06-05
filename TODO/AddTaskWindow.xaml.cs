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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class AddTaskWindow : Window
	{
		private MainWindow mainwindow = null;

		public AddTaskWindow(MainWindow mwindow)
		{
			InitializeComponent();
			mainwindow = mwindow;
		}

		private void addTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			if(prioritycmbbox.Text != "" && tasktxtbox.Text != "" && datepicker.Text != "")
			{
				TODOTask todotask = new TODOTask { 
					priority = prioritycmbbox.Text, 
					task = tasktxtbox.Text,
					datetime = datepicker.Text
				};
				mainwindow.addTaskToList(todotask);
				this.Close();
			}
			else
			{
				MessageBox.Show("Uzupełnij wszystkie pola.");
			}
		}
	}
}
