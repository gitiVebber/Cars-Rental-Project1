   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   
bsd.profit   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  profit��$	��500��$	��500�� � 	Resources    rentingViewSource��%   &	        �� .��� $	��500��$	��480�� � DataContext# [   � ColumnDefinitions �� $	��87* ��� $	��13* �.+��� -    ��Name$ IDcombox��$
��Left=�$��
338,93,0,0q�$	��Top=�$	��120��$��2��$
��Bold"�$��14(�(  "System.Windows.Controls.DatePicker  -     Name$ startDatePicker��$
��Left=�$��	33,91,0,0q�$	��Top=�$
��Bold"�$��14(�  -   $ endDatePicker��$
��Left=�$��
178,91,0,0q�$	��Top=�$
��Bold"�$��14(��� $��select client��$
��Left=�$��
338,46,0,0q�$	��Top=�$
��Bold"�$��14(��� $��
start date��$
��Left=�$��	33,46,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.659,1.854&�$
��Bold"�$��14(��� $��end date��$
��Left=�$��
178,46,0,0q�$	��Top=�$ 0.974,0.913&�$
��Bold"�$��14(��� $.��(Total revenue from customer all years - ��$
��Left=�$��	0,424,0,0q�$	��Top=�$ 0.203,-0.399&�$	��387��$��44��$
��Bold"�$��20(��� -    ��Name$ CostPriceTextBox��$
��Left=�$��32��$��387,428,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��103��$
��Bold"�$��18(�$��2��&   System.Windows.Controls.DataGrid  -   	  Name$	 rentingDataGrid��
   AutoGenerateColumns
 .  $��2��   EnableRowVirtualization . $��42,128,42,146q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�{�.  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   chairBabyColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
chair Baby��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	chairBaby+  -   chairChildColumn��$ chair Child��$ SizeToHeader  �� *
chairChild+  -	   isFaultColumn��$ is Fault��$ SizeToHeader  �� *	isFault+  -
   isGPSColumn��$ is GPS��$ SizeToHeader  �� *isGPS+  -   licensePlateColumn��$ license Plate��$ SizeToHeader  �� *licensePlate+  -   numberCallColumn��$ number Call��$ SizeToHeader  �� *
numberCall+  -   priceColumn��$ price��$ SizeToHeader  �� *price+�� $*��$calculation cost price for a client:��$
��Left=�$��58,10,0,434q�$��20(�$
��Bold"��� -   $ profitTextBox��$
��Left=�$��23��$��305,357,0,0q�$
 Wrap=�$	��Top=�$	��120���� $0��*profit from this client between this date:��$
��Left=�$��
42,357,0,0q�$	��Top=�$	��232��