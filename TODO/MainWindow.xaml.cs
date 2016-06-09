using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Reactive.Linq;

namespace TODO
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<TODOTask> todolist = new List<TODOTask>();
		public List<TODOTask> completedTaskList = new List<TODOTask>();
	
		System.Windows.Forms.NotifyIcon notifyicon;
		public int indexToRemove = -1;
		
		public MainWindow()
		{
			InitializeComponent();
			initSystemTray();
			viewInfoAboutTasksForToday();
		}

		protected void viewInfoAboutTasksForToday()
		{
			var refresh = Observable.Interval(TimeSpan.FromSeconds(10));
			refresh.Subscribe(tick =>
			{
				viewTaskForToday();
				checkEndlessTasksFromPast();
			});
		}
		
		public string checkEndlessTasksFromPast()
		{
			var endlessTasksList = from task in todolist
								   where DateTime.Parse(task.datetime) < DateTime.Today
								   select task;
			string messageAboutTasksFromPast="";

			if (endlessTasksList.Count() > 0)
			{
				if(endlessTasksList.Count() == 1)
				{
					messageAboutTasksFromPast = "Nie zrobiłeś " + endlessTasksList.Count() + " zadania z poprzednich dni.";
					System.Windows.Forms.MessageBox.Show(messageAboutTasksFromPast);
				}
				else
				{
					messageAboutTasksFromPast = "Nie zrobiłeś " + endlessTasksList.Count() + " zadań z poprzednich dni.";
					System.Windows.Forms.MessageBox.Show(messageAboutTasksFromPast);
				}
			}
			return messageAboutTasksFromPast;
		}

		protected void initSystemTray()
		{
			notifyicon = new System.Windows.Forms.NotifyIcon();
			notifyicon.Icon = new System.Drawing.Icon("test.ico");
			notifyicon.Visible = true;
			notifyicon.Click +=
				delegate(object sender, EventArgs args)
				{
					this.Show();
					this.WindowState = WindowState.Normal;
				};
		}

		public string viewTaskForToday()
		{
			string messageAboutTasksForToday = "";
			List<TODOTask> listtasksfortoday = todolist.Where(x => x.datetime == DateTime.Today.ToShortDateString()).ToList();
			
			if(listtasksfortoday.Count > 0)
			{
				if(listtasksfortoday.Count == 1)
				{
					messageAboutTasksForToday = "Masz dzisiaj do zrobienia " + listtasksfortoday.Count + " zadanie.";
					System.Windows.Forms.MessageBox.Show(messageAboutTasksForToday);
				}
				else
				{
					messageAboutTasksForToday = "Masz dzisiaj do zrobienia " + listtasksfortoday.Count + " zadań.";
					System.Windows.Forms.MessageBox.Show(messageAboutTasksForToday);
				}
			}
			return messageAboutTasksForToday;
		}

		protected override void OnStateChanged(EventArgs e)
		{
			if (WindowState == System.Windows.WindowState.Minimized)
			{
				this.ShowInTaskbar = false;
				notifyicon.BalloonTipTitle = "Minimalizacja zakończona";
				notifyicon.BalloonTipText = "Zminimalizowano aplikację";
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

		public void sortlist()
		{
			todolist = todolist.OrderBy(x => x.datetime).ThenByDescending(y => y.priority).ToList();
		}

		public void addTaskToList(TODOTask todotask)
		{
			todolist.Add(todotask);
			datagrid.ItemsSource = null;
			sortlist();
			datagrid.ItemsSource = todolist;
		}

		public void removeTaskFromList()
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

		public void restoreCompletedTasks()
		{
			todolist = todolist.Concat(completedTaskList).ToList();
			datagrid.ItemsSource = null;
			sortlist();
			datagrid.ItemsSource = todolist;
			completedTaskList.Clear();
		}

		private void restoreCompletedTasksBtn_Click(object sender, RoutedEventArgs e)
		{
			if(completedTaskList.Count > 0)
			{
				restoreCompletedTasks();
			}
		}
	}
}