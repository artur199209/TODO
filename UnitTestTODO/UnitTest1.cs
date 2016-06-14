using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO;

namespace UnitTestTODO
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestaddTaskToList()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Wysoki.ToString();
			todotask.task = "test";
			mainwindow.addTaskToList(todotask);
			int todolistlength = mainwindow.todolist.Count;
			Assert.AreEqual(1, todolistlength);
		}

		[TestMethod]
		public void TestremoveTaskFromList()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Wysoki.ToString();
			todotask.task = "removetaskfromlist";
			mainwindow.addTaskToList(todotask);
			mainwindow.todolist.RemoveAt(0);
			int value = mainwindow.todolist.Count;
			Assert.AreEqual(0, value);
		}

		[TestMethod]
		public void TestcheckIsEndlessTasksFromPast()
		{
			MainWindow mainwindow = new MainWindow();
			Assert.IsNotNull(mainwindow.checkAreEndlessTasksFromPast());
		}

		[TestMethod]
		public void TestcheckIsTasksFromPast()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = "2016-06-01";
			todotask.priority = Priorities.Priority.Wysoki.ToString();
			todotask.task = "Test";
			mainwindow.addTaskToList(todotask);
			string expected = "Nie zrobiłeś 1 zadania z poprzednich dni.";
			Assert.AreEqual(expected, mainwindow.checkAreEndlessTasksFromPast());
		}

		[TestMethod]
		public void TestcheckTasksForToday()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Wysoki.ToString();
			todotask.task = "Test";
			mainwindow.addTaskToList(todotask);
			string expected = "Masz dzisiaj do zrobienia 1 zadanie.";
			Assert.AreEqual(expected, mainwindow.checkTaskForToday());
		}

		[TestMethod]
		public void TestcheckIsNotTasksForToday()
		{
			MainWindow mainwindow = new MainWindow();
			Assert.IsNotNull(mainwindow.checkTaskForToday());
		}

		[TestMethod]
		public void TestremoveTaskFromListByIndex()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.task = "test";
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Wysoki.ToString();
			mainwindow.addTaskToList(todotask);
			mainwindow.indexToRemove = 0;
			mainwindow.removeTaskFromList();
			Assert.AreEqual(0, mainwindow.todolist.Count);
		}

		[TestMethod]
		public void TestrestoreCompletedTasks()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Średni.ToString();
			todotask.task = "test";
			mainwindow.completedTaskList.Add(todotask);
			mainwindow.restoreCompletedTasks();
			int expected = 0;
			Assert.AreEqual(expected, mainwindow.completedTaskList.Count);
		}

		[TestMethod]
		public void TestCheckToDoListafterRestoreCompletedTasks()
		{
			MainWindow mainwindow = new MainWindow();
			TODOTask todotask = new TODOTask();
			todotask.datetime = DateTime.Now.ToShortDateString();
			todotask.priority = Priorities.Priority.Średni.ToString();
			todotask.task = "test";
			mainwindow.completedTaskList.Add(todotask);
			mainwindow.restoreCompletedTasks();
			int expected = 1;
			Assert.AreEqual(expected, mainwindow.todolist.Count);
		}
	}
}
