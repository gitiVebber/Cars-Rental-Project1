   M S B A M L   `   `   `  ���� =  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE   bsd   PLfrom.typeFault   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +BEclr-namespace:BE;assembly=BE     -     � Title$  	typeFault��$	��236��$	��300�� � 	Resources    tybeFaultViewSource  faultViewSource��%   &	        &	      �� �� .��� .+�� -    �Name$ grid1�� � DataContext# [  $
��Left=�$��	51,55,0,0q�$	��Top=� � ColumnDefinitions �� $
��Auto ��� $
��Auto � � RowDefinitions �� $
��Auto �.+��� $��name Fault:��$��0��$
��Left=�$��3q�$��0��$��Center=�$��15(�$
��Bold"��� -    ��Name$ nameFaultTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��120������ *	nameFault+ �� Mode$ TwoWay=� �� NotifyOnValidationError . 	 �� ValidatesOnExceptions	 . � -   $ grid2��# [  $
��Left=�$��	34,20,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��number Fault:��$��0��$
��Left=�$��3q�$��0��$��Center=�$��15(�$
��Bold"��� -   $ numberFaultTextBox��$��1��$
��Left=�$��23��$��3q�$��0��$��Center=�$	��120������ *numberFault+$ TwoWay=� . 	 . � -   $ grid3��# [ $
��Left=�$��	17,92,0,0q�$	��Top=�$	��258�� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��price Of Fault:��$��1��$
��Left=�$��19,0,0,3q�$��0��$��Bottom=�$��15(�$
��Bold"��� -   $ priceOfFaultTextBox��$��1��$
��Left=�$��23��$��	134,5,0,5q�$��0��$��Center=�$	��120������ *priceOfFault+$ TwoWay=� . 	 . �� -   
 ��Name$
 addTybeFaultBotton��$	��add��$
��Left=�$��
75,156,0,0q�$	��Top=�$	��129��$��34��$��20(�$
��Bold"�� -	   $ grid4��# [  $
��Left=�$��
34,124,0,0q�$	��Top=�$	��242�� �� $��0 ��� $	��114 ��� $
��Auto �$	��126�� �� $��29 ��� $��4 �.+��� $��
insurance:��$��1��$
��Left=�$��29,0,0,3q�$
��Bold"�$��0��$��Bottom=�$��15(�$��30��$��82��$��2���� -
    ��Name$ insuranceComboBox��$��2��$
��Left=�$��22��$��2,6,0,1q�$��0��$��Center=�$	��120������ .@��� $��comprehensive���� $��handicap insurance��