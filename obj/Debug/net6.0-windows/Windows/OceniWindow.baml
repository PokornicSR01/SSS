   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   +    %SSS_Projekat_Miju.Windows.OceniWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  AddEditWindow��5   	   $	��200��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #0f7833��6    � Offset$	 0.1Q�6+   � 5      $ #960000��6   $	 0.8Q�6+   5      .��5      � $��0,0,0,4q�6    � ColumnDefinitions 5   
   �� 5      $��97 �6   6,   �� 5      $
��160* �6   6.    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $	��100 �6   6+   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $
��Left=�6    $��Center=�6;   $��2��6V   $��26��6j   $��0q�6v   $��80��6�   .��6�   Ocena(1-5):6�   �� 5   
   -   5        $��	txtUplata��5      $��0��6$   $��1��61   $��5,5,5,5q�6A   $��2��6R   .��6g   5      �� 5!   
   $��0��6   $��1��6    $
��Left=�6-   $��Center=�6H   $��2��6c   $��26��6w   $��0q�6�   $��70��6�   .��6�   	Komentar:6�   �� 5"   
   -   5        $��txtKomentar��5"      $��1��6&   $��2��63   $��5,5,5,5q�6C   $��2��6T   .��6h   5#      � 5%   
   $��15��6   $��2��6   $��Bottom=�6-   $��Right=�6H   $��40��6d   $	��120��6p    5&      �� 5'      6%   �� 5(      6%   .+�5*      �� -   5         ��Name$ 
btnPonisti��5*      $��0��6B   $��50��6R   $��30��6]   $��Right=�6i   $��5,5,5,5q�6�   .��6�   	Ponisti6�   �� 5+      -   5        $ 
btnSacuvaj��5+      $��1��6B   $��50��6R   $��30��6]   $��5,5,5,5q�6j   .��6{   	Sacuvaj6�   5,      5.      5/      