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
using System.Drawing;
using System.Windows.Forms;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<TODOTask> todolist = new List<TODOTask>();
		List<TODOTask> completedTaskList = new List<TODOTask>();
		System.Windows.Forms.NotifyIcon notifyicon;
		int indexToRemove = -1;

		public MainWindow()
		{
			InitializeComponent();
			todolist.Add(new TODOTask { priority = "DSA", task = "fd" });
			datagrid.ItemsSource = todolist;
			todolist.Add(new TODOTask { priority = "DSA", task = "fd" });
			datagrid.ItemsSource = todolist;
			notifyicon = new System.Windows.Forms.NotifyIcon();
			notifyicon.Icon = new System.Drawing.Icon("test.ico");
			notifyicon.Visible = true;
			notifyicon.DoubleClick +=
				delegate(object sender, EventArgs args)
				{
					this.Show();
					this.WindowState = WindowState.Normal;
				};
		}

		protected override void OnStateChanged(EventArgs e)
		{
			if (WindowState == System.Windows.WindowState.Minimized)
			{
				this.ShowInTaskbar = false;
				notifyicon.BalloonTipTitle = "Minimize Sucessful";
				notifyicon.BalloonTipText = "Minimized the app ";
				notifyicon.ShowBalloonTip(400);
				notifyicon.Visible = true;
			}
			else if (this.WindowState == WindowState.Normal)
			{
				notifyicon.Visible = false;
				this.ShowInTaskbar = true;
			}
			base.OnStateChanged(e);
		}

		public void addTaskToList(TODOTask todotask)
		{
			todolist.Add(todotask);
			datagrid.ItemsSource = null;
			datagrid.ItemsSource = todolist;
		}

		public void removeTaskFromList(TODOTask tasktoremove)
		{
			todolist.RemoveAt(indexToRemove);
		}

		private void addTaskToListBtn_Click(object sender, RoutedEventArgs e)
		{
			AddTaskWindow addtaskwindow = new AddTaskWindow(this);
			addtaskwindow.ShowDialog();
		}

		private void deleteTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			int index = datagrid.SelectedIndex;
			if (index != -1 && index < todolist.Count)
			{
				todolist.RemoveAt(index);
				datagrid.ItemsSource = null;
				datagrid.ItemsSource = todolist;
			}
		}

		private void editTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			int index = datagrid.SelectedIndex;
			if (index != -1 && index < todolist.Count)
			{
				indexToRemove = index;
				TODOTask tasktoedit = (TODOTask)datagrid.Items[index];
				EditTaskWindow edittaskwindow = new EditTaskWindow(this, tasktoedit);
				edittaskwindow.Show();
			}
		}

		private void setTaskAsDoneBtn_Click(object sender, RoutedEventArgs e)
		{
			int index = datagrid.SelectedIndex;
			if (index != -1 && index < todolist.Count)
			{
				TODOTask completedtask = (TODOTask)datagrid.Items[index];
				completedTaskList.Add(completedtask);
				todolist.RemoveAt(index);
				datagrid.ItemsSource = null;
				datagrid.ItemsSource = todolist;
			}
		}

		private void restoreCompletedTasksBtn_Click(object sender, RoutedEventArgs e)
		{
			if(completedTaskList.Count > 0)
			{
				todolist = todolist.Concat(completedTaskList).ToList();
				datagrid.ItemsSource = null;
				datagrid.ItemsSource = todolist;
				completedTaskList.Clear();
			}
		}
	}
}
