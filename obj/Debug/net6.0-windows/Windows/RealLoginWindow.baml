   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   /    )SSS_Projekat_Miju.Windows.RealLoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  RealLoginWindow��5   	   $	��250��6!   $	��400��6.    � WindowStartupLocation$ CenterScreen=�6:   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ YellowGreen��6    � Offset$
 0.25Q�6/   � 5      $ 
WhiteSmoke��6   $	 1.5Q�6.   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��60 �6   6,   �� 5      6"   �� 5      6"    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $
��Left=�6    $��Center=�6;   $
��auto��6V   $��0,0,0,0q�6d   $��69��6u    J� RenderTransformOrigin$ 0.5,0.5&�6�   .��6�   Email:6�   �� 5    
   -   5        $��txtEmail��5       $��0��6#   $��1��60   $
��8,22q�6A   $��2��6O   .��6c   	 � 	Resources	 5!      
 �� 
TargetType �� Property �� Value��%^   '��       �� 5"      "
 ��6   .�5#      ��  �@��CornerRadius$ 5��65   5$      5%      .��6!   5&      �� 5(   
   $��1��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��2��6c   $��26��6w   $��0q�6�   $��62��6�   .��6�   
Lozinka:6�   G� 5)   
   -   5        $��
txtLozinka��5)      $��1��6(   $��1��65   $
��8,22q�6E   $��2��6S   	 5*      ��%^   '��       �� 5+      "
 ��6   .�5,      ��  �@��CornerRadius$ 5��65   5-      5.      5/      �� 51   
   -   5        $��btnLogin��51      $��2��68   $��1��6E   $
��8,22q�6V   $��Login��6d   	 52      ��%^   '��       �� 53      "
 ��6   .�54      ��  �@��CornerRadius$ 5��65   55      56      57      �� 58   
   -   5        $��btnNazad��58      $��2��68   $��2��6E   $
��8,22q�6V   $��Nazad��6d   	 59      ��%^   '��       �� 5:      "
 ��6   .�5;      ��  �@��CornerRadius$ 5��65   5<      5=      5>      5@      5A      