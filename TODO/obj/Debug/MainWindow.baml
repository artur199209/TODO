   M S B A M L   `   `   `  ����  TODO    TODO.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	ToDo List��5   	   $	��350��6   $	��525��6(    � 
ResizeMode$ CanMinimize=�64   .��5      � .+�5   
   � $
��Left=�6   $	��299��6*   $��10,0,0,0q�67   $	��Top=�6I   $	��497��6a    � ColumnDefinitions 5      �� 5      $	��16* �6#   �� 5	      $
��281* �6#   �� 5
      $
��200* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $	��125��6o   $	��317��6|   $��3��6�      Columns 5      5      �� 5      -   5         ��Name$ addTaskToListBtn��5      $��Dodaj��6/   $
��Left=�6?   $��	59,13,0,0q�6Z   $	��Top=�6m   $	��110��6�   $��2��6�   �� 5      -   5        $ deleteTaskBtn��5      $��Usuń��6,   $��2��6;   $
��Left=�6K   $��	59,49,0,0q�6f   $	��Top=�6y   $	��110��6�   6�   �� 5      -   5        $ editTaskBtn��5      $��Edytuj��6*   $��2��6;   $
��Left=�6K   $��	59,88,0,0q�6f   $	��Top=�6y   $	��110��6�   6�   �� 5      -   5        $ setTaskAsDoneBtn��5      $��Zakończ zadanie��6/   $��2��6I   $
��Left=�6Y   $��
59,120,0,0q�6t   $	��Top=�6�   $	��110��6�   6�   �� 5      -   5        $ restoreCompletedTasksBtn��5      $��Przywróć zrobione��67   $��2��6S   $
��Left=�6c   $��
59,160,0,0q�6~   $	��Top=�6�   $	��110��6�   6�   5      5      5      