   M S B A M L   `   `   `  ????E  AHomework17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Homework17
Homework17  5   	       Homework17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Homework17     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??194* ?6   ?? 5      $	??23* ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 Data??5      $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5         SelectionMode$ Single=?5         AutoGenerateColumns .     
IsReadOnly .  ??5      ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Id??,  &System.Windows.Controls.DataGridColumn   Header$ Id??5   %   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   %   ?? *Id+5   9     5      -   5        Surname??$ Фамилия??5    %   
 5   %   ?? *	Surname+5    8     5"      -   5        Name??$ Имя??5$   %   
 5#   %   ?? *Name+5$   4     5&      -   5        Midname??$ Отчество??5(   %   
 5'   %   ?? *	Midname+5(   9     5*      -   5        	Phone??$ Телефон??5,   %   
 5+   %   ?? *Phone+5,   8     5.      -   5        	Email??$ Email??50   %   
 5/   %   ?? *Email+50   6    ? ContextMenu 52      ?? 53      .@?54      m? -   5        $??Добавить??54      55      m? 57      -	   5        $??Удалить??57      58      m? 5:      -
   5        $#??Показать заказы??5:      5;   ;   5<      5>      ?? 5?   
   -   5         ??Name$ conStr??5?      $??1??5@      $??10q?5A      $??12(?5B      6$   5C      5D      