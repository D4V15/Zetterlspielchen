   M S B A M L   `   `   `  ����K  GZetterlspielchen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ZetterlspielchenZetterlspielchen  5   	   !    Zetterlspielchen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Zetterlspielchen     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��0��5       �� 
IsReadOnly .  J� 	AllowDrop .  �� TextWrapping$
 Wrap=�6�   ��6   �� *	LastMsg+6�   �� 5   
   $��1��6   $
 Wrap=�68   ��6   �� *	ThisMsg+68   � 5   
   $��2��6    � Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�5      �� -   5        $��	Auflösen��5      $��10q�6(   64   �� 5      -   5        $��Ordner öffnen��5      $��10q�6-   69   �� 5      -   5        $��Fertig��5      $��10q�6&   62   5      5      5      