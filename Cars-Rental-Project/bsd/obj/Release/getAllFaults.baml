   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   bsd.getAllFaults   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  getAllFaults��$	��600��$	��700�� � 	Resources    faultViewSource��%   &	        �� .��� $	��700��$	��600�� � DataContext# [  .+��� -    ��Name$ lable1��$%��select all faults of the system��$
��Left=�$��
101,27,0,0q�$	��Top=�$��36(��� -   $ lable2��$��that came by laches��$
��Left=�$��
114,90,0,0q�$	��Top=�$��22(�&   System.Windows.Controls.DataGrid  -     Name$ faultDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��117,230,134,121q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   dateOfFaultColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 date Of Fault��
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *dateOfFault+  -   garageOfFixColumn��$	 garage Of Fix��$
 SizeToHeader  �� *garageOfFix+  -   isWearColumn��$	 is Wear��$
 SizeToHeader  �� *isWear+  -   numberCarColumn��$	 
number Car��$
 SizeToHeader  �� *	numberCar+  -	   numberFaultColumn��$	 number Fault��$
 SizeToHeader  �� *numberFault+  -
   priceOfFaultColumn��$	 price Of Fault��$
 SizeToHeader  �� *priceOfFault+