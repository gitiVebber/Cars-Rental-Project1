   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   bsd.getAllCar   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  	getAllCar��$	��600��$	��800�� � 	Resources    carViewSource��%   &	        �� .���  � DataContext# [  $	��800��$	��600��$��110,0,-618,-331q� � RowDefinitions �� �� $��7* � � ColumnDefinitions �� $
��138* ��� $	��31* ��� $
��631* �.+�&   System.Windows.Controls.DataGrid  -     Name$ carDataGrid��   AutoGenerateColumns .  $��3��   EnableRowVirtualization . $��-288,35,438,260q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�$	��650��$��2��{�.  ���� 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  -   adressBranchColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 adress Branch��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *adressBranch+  -   creatureCarColumn��$
 creature Car��$ SizeToHeader  �� *creatureCar+  -   dateLicensedColumn��$
 date Licensed��$ SizeToHeader  �� *dateLicensed+  -   isAutomatColumn��$
 
is Automat��$ SizeToHeader  �� *	isAutomat+  -   kMColumn��$
 KM��$ SizeToHeader  �� *KM+  -   licensePlateColumn��$
 License Plate��$ SizeToHeader  �� *LicensePlate+  -	   numberCarColumn��$
 
number Car��$ SizeToHeader  �� *	numberCar+  -
   sumDoorsColumn��$
 	sum Doors��$ SizeToHeader  �� *
sumDoors+  -   sumTravelersColumn��$
 sum Travelers��$ SizeToHeader  �� *sumTravelers+�� -    ��Name$ sumDoorsCombox��$
��Left=�$��-98,-44,0,0q�$	��Top=�$	��120���� -   $ 	girCombox��$
��Left=�$��-98,-48,0,101q�$	��120���� -    ��Name$ lable��$��select according to:��$
��Left=�$��-301,-145,0,0q�$	��Top=��� -   $ label3��$��sit places:��$
��Left=�$��-206,-62,0,0q�$	��Top=��� -   $ lable2��$��
sum doors:��$
��Left=�$��-206,-48,0,0q�$	��Top=��� -   $ label1��$��is automaton:��$
��Left=�$��-206,-52,0,0q�$	��Top=��� -   $ lable10��$$��select all cars of the system:��$
��Left=�$��-158,-145,0,0q�$	��Top=�$��20(��� -    ��Name$ sitPlaceTextBox��$
��Left=�$��23��$��-101,-58,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -    ��Name$ 
showBotton��$
��show��$
��Left=�$	��Top=�$��75��$��3��$��115,-57,0,0q��� -   $ textBoxProfit��$
��Left=�$��23��$��
45,297,0,0q�$��1��$
 Wrap=�$��TextBox��$	��Top=�$	��114��$��2���� -   $ labeltextBoxProfit��$ ��the prifit of all cars is:��$��-240,297,42,0q�$��1��$	��Top=�$��20(�