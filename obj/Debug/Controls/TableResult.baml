   M S B A M L   `   `   `  ����  MCS    MCS.Controls.TableResult   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��2q�5      &   System.Windows.Controls.DataGrid    CanUserAddRows  .     AutoGenerateColumns .     VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �����   AlternatingRowBackground
 �����
�������$��1q�5      
�������$   HorizontalScrollBarVisibility$
 Auto=�5      "   VerticalScrollBarVisibility$
 Auto=�5       %� VirtualizationMode$ 	Recycling=�5      $��Center=�5      ��5	      �� *SimResultList+ � 	Resources 5      	 �� Color��%�   (��       5      * SystemColors.HighlightBrushKey+)(�� !     5      *$"SystemColors.HighlightTextBrushKey+)�� 5      $	 #FFE9B5��6P   �� 5      $	 #015874��6T   5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5   
   ,  &System.Windows.Controls.DataGridColumn   Header$ Cummulative Frequency��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *CumulativeFrequency+  5    
   $ Relative Frequency��6   $ * 5!   *    5"   )   �� *RelativeFrequency+  5$   
   $ Expectation��6   $ * 5%   *    5&   )   �� *Expectation+5)      