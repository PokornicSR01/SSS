   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   +    %SSS_Projekat_Miju.Windows.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*   
������� � WindowStartupLocation$ CenterScreen=�5	       .��5
      �  J� RenderTransformOrigin$ 0.504,0.233&�6   .+�5   
   o� $��	0,0,0,385q�6   .@�5      m� -   5        $��	miTreneri��5      $��Treneri��6(   $��70��6Q   m� 5      -   5        $��
miKlijenti��5      $��Klijenti��6)   $��70��6T   m� 5      -   5        $��	miTermini��5      $��Termini��6(   $��70��6Q   5      o� 5   
   -   5        $��
trenerMenu��5      $��
0,25,0,351q�6"   .@�5      m� -   5        $��miAddTrener��5      $��Dodaj trenera��6*   $	��100��6[   m� 5      -   5        $��miUpdateTrener��5      $��Izmeni trenera��6-   $	��100��6b   m� 5      -   5        $��miDeleteTrener��5      $��Obrisi trenera��6-   $	��100��6b   m� 5      -   5        $��miVerifikujProfesora��5      $"��Verifikuj/Ukini verifikaciju��63   $	��150��6|   m� 5      -	   5        $��miAddKlijent��5      $��Dodaj Klijent��6+   $	��100��6]   m� 5      -
   5        $��miUpdateKlijent��5      $��Izmeni Klijent��6.   $	��100��6d   m� 5      -   5        $��miDeleteKlijent��5      $��Obrisi Klijent��6.   $	��100��6d   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��
myDataGrid��5   =      CanUserAddRows$ False��6      
IsReadOnly$
 True��6+   $��	0,64,0,10q�6O   ��5      �� 5        �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5!      �  � Color$ #ec7e15��6#    � Offset$
 0.01Q�63   � 5"      $ #3d3a39��6#   $	 0.9Q�63   5#      5%      �� 5&   
   -   5        $��	btnOdjava��5&      $��304,377,376,10q�6:   $��Odjava��6R   	 � 	Resources	 5'      
 �� 
TargetType �� Property �� Value��%^   '��       �� 5(      "
 ��6   .�5)      ��  �@��CornerRadius$ 5��65   5*      5+      5,      5-      5.      