   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   bsd.getClients   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  
getClients��$	��700��$	��700�� � 	Resources    clientViewSource��%   &	        �� .��� $	��800��$	��660�� � DataContext# [   � ColumnDefinitions �� $
��160* ��� $	��11* ��� $
��629* �.+��� -    ��Name$ Combox��$��3��$
��Left=�$��
146,41,0,0q�$	��Top=�$	��120���� -    ��Name$ lable2��$*��$select clients by month of birthday:��$
��Left=�$��
146,10,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.474,1.256&�$��3���� -   $ lable1��$��all clients:��$��2��$
��Left=�$��
132,41,0,0q�$	��Top=�$ 	0.915,0.5&��� -   $ lable3��$&�� select all clients that get gps:��$
��Left=�$��	40,72,0,0q�$	��Top=�$	��283��$��20(�$��3��&   System.Windows.Controls.DataGrid  -     Name$ clientDataGrid��   AutoGenerateColumns .  	   EnableRowVirtualization	 . $��40,135,138,146q�
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�$��3������    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   iDClientColumn��,  &System.Windows.Controls.DataGridColumn   Header$     IDClient    ��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IDClient+  -   lastNameColumn��$ 	last Name��$ SizeToHeader  �� *
lastName+  -	   
nameColumn��$ 
first name��$ SizeToHeader  �� *name+  -
   addressClientColumn��$ address Client��$ SizeToHeader  �� *addressClient+  -   codePelePhoneColumn��$         ��$ SizeToHeader  �� *codePelePhone+  -   numPelePhoneColumn��$ num Pele Phone��$ SizeToHeader  �� *numPelePhone+  -   dateOfBirthColumn��$     date Of Birth    ��$ SizeToHeader  �� *dateOfBirth+  -   emailColumn��$          Email       ��$ SizeToHeader  �� *Email+