   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   +    %SSS_Projekat_Miju.Windows.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  LoginWindow��5   	   $	��200��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�66   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ YellowGreen��6    � Offset$
 0.25Q�6/   � 5      $ 
WhiteSmoke��6   $	 1.5Q�6.   5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5        $��
btnKlijent��5   (   $��30��6   $��80��6   $��Klijent��6S   $��0��6e   $��0��6u   
������� � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��65   5      5       5!      �� 5"   
   -   5        $��	btnTrener��5"   (   $��30��6   $��80��6   $��Trener��6Q   $��0��6c   $��1��6s   
������� 5#      ��%^   '��       �� 5$      "	 ��6   .�5%      �� 
 �@��CornerRadius$ 5��65   5&      5'      5(      �� 5*   
   -   5        $��	btnCancel��5*   (   $��30��6   $��80��6   $��Nazad��6Q   $��0��6a   $��2��6q   
������� 5+      ��%^   '��       �� 5,      "	 ��6   .�5-      �� 
 �@��CornerRadius$ 5��65   5.      5/      50      52      53      