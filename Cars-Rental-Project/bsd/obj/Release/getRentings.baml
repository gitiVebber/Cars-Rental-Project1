   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   bsd.getRentings   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  getRentings��$	��600��$	��800�� � 	Resources    rentingViewSource��%   &	        �� .���  � DataContext# [  $	��500��$��0,48,-208,-231q� � ColumnDefinitions �� $	��71* ��� $
��179* �.+��� -    ��Name$ getRentingsCombox��$
��Left=�$��-155,68,0,0q�$	��Top=�$	��198��$��31��&   System.Windows.Controls.DataGrid  -     Name$ rentingDataGrid��   AutoGenerateColumns .  $��2��   EnableRowVirtualization . $��-126,130,49,285q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�{�.  ���� 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  -   chairBabyColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 
chair Baby��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	chairBaby+  -   chairChildColumn��$
 chair Child��$ SizeToHeader  �� *
chairChild+  -   endRentingColumn��$
 end Renting��$ SizeToHeader  �� *
endRenting+  -   isGPSColumn��$
 is GPS��$ SizeToHeader  �� *isGPS+  -   licensePlateColumn��$
 license Plate��$ SizeToHeader  �� *licensePlate+  -	   numberCallColumn��$
 number Call��$ SizeToHeader  �� *
numberCall+  -
   priceColumn��$
 price��$ SizeToHeader  �� *price+  -   startRentingColumn��$
 Start Renting��$ SizeToHeader  �� *StartRenting+�� -    ��Name$ selectClient��$.��(select a client to show all his Rentals:��$
��Left=�$��-155,27,0,0q�$	��Top=�$��36��$	��413��$��20(�$
��Bold"�$��2���� -   $ allRentings��$ ��all Rentings of the system��$
��Left=�$��	-48,0,0,0q�$	��Top=�$��2��$��51��$	��335��$��24(�$
��Bold"�