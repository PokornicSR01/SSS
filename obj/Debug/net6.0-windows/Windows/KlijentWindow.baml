   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   -    'SSS_Projekat_Miju.Windows.KlijentWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  KlijentWindow��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #352d77��6    � Offset$
 0.25Q�6+   � 5      $ #b81254��6   $	 1.5Q�6+   5      .��5      � .+�5   
   o� $��	0,0,0,170q�6   .@�5      m� -   5        $��miSviTreneri��5      $��Treneri��6+   $
��auto��6W   m� 5      -   5        $��miTreneroviTermini��5      $��Termini��61   $
��auto��6c   m� 5      -   5        $��miRezervisiTermin��5      $��Rezervisi/Otkazi��60   $
��auto��6j   m� 5      -   5        $��miUplatiNovac��5      $��Uplati Novac��6,   $
��auto��6^   m� 5      -   5        $��miOceniTrenera��5      $��Oceni Trenera��6-   $
��auto��6a   m� 5      -   5        $��miMojiTermini��5      $��MojiTermini��6,   $
��auto��6]   m� 5      -   5        $��miTreningUzivo��5      $��Trening uzivo��6-   $��90��6a   m� 5      -   5        $��miMojiTreneri��5      $��Moji Treneri��6,   $��90��6^   m� 5      -	   5        $��miMojiPodaci��5      $��Moji Podaci��6+   $��90��6[   5      &   System.Windows.Controls.DataGrid  5   
   -
   5        $��
myDataGrid��5   <      CanUserAddRows$ False��6      
IsReadOnly$
 True��6*   $��0,55,0,0q�6N   $��2��6`   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #352d77��6#   $	 0.1Q�63   � 5      $ #b81254��6#   $ 1Q�63   5       5"      �� 5#   
   -   5        $��	btnOdjava��5#      $��304,377,376,10q�6:   $��Odjava��6R    � 	Resources 5$      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5%      "	 ��6   .�5&      �� 
 �@��CornerRadius$ 5��65   5'      5(      5)      5*      5+      