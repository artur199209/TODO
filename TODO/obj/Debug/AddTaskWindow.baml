   M S B A M L   `   `   `  ����  TODO    TODO.AddTaskWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddTaskWindow��5   	   $��426.866��6   $��434.328��60    � 
ResizeMode$ CanMinimize=�6@   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��32* �6   �� 5      $
��146* �6   �� 5	      $	��40* �6   �� 5
      $	��53* �6   �� 5      $
��125* �6   �� 5      $	��30* �6   .+�5   
   �� -   5         ��Name$ 
addTaskBtn��5      $��Dodaj zadanie��6%   $
��Left=�6=   $��136,338,0,0q�6X   $	��Top=�6m   $	��103��6�   $��3��6�   $��1��6�   �� 5   
   $��	Priorytet��6   $
��Left=�6$   $��10,5,0,0q�6?   $	��Top=�6Q   $��2��6i   �� 5   
   $��Zadanie��6   $
��Left=�6"   $��	10,80,0,0q�6=   $	��Top=�6P    J� RenderTransformOrigin$ 1.584,1.342&�6h   $��2��6�   �� 5   
   -   5         ��Name$ 
tasktxtbox��5      $
��Left=�6&   $��59��6A   $��
10,111,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��375��6�   $��5��6�   �� 5   
   -   5         ��Name$ prioritycmbbox��5      $
��Left=�6+   $��	10,36,0,0q�6F   $	��Top=�6Y   $	��120��6q   $��2��6}   5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datepicker��5      $
��Left=�6)   $��
10,249,0,0q�6D   $	��Top=�6X   $��48��6p   $	��132��6|   $��2��6�   �� 5   
   $
��Data��6   $
��Left=�6   $��
10,202,0,0q�6:   $	��Top=�6N   $ 0.581,2.571&�6f   $��2��6�   5      5      