   M S B A M L   `   `   `  ����L  HSSS-Projekat-Miju, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SSS_Projekat_Miju.WindowsSSS_Projekat_Miju.Windows  5   	   -    'SSS_Projekat_Miju.Windows.AddEditTrener   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SSS_Projekat_Miju.Windows     5   	     � Title$  AddEditTrener��5   	   $	��451��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ GreenYellow��6    � Offset$
 0.25Q�6/   � 5      $ Green��6   $	 1.4Q�6)   5      .��5      � $��0,0,0,0q�6    � ColumnDefinitions 5   
   �� 5      $��97 �6   6,   �� 5      $
��160* �6   6.   �� 5      $
��143* �6    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5       $��30 �6   6*   �� 5!      $��30 �6   6*   �� 5"      $��* �6   6)   .+�5%   
   �� $��0��6   $
��Left=�6    $��Center=�6;   $��2��6V   $��26��6j   $��0q�6v   $��41��6�   .��6�   Email:6�   �� 5&   
   -   5        $��txtEmail��5&      $��0��6#   $��1��60   $��5,5,5,5q�6@   $��2��6Q   ��6e   ��  �� Path$ korisnik.eMail�	 �� ValidatesOnDataErrors$
	 True��.��6�   5'      �� 5)   
   $��1��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��2��6c   $��26��6w   $��0q�6�   $��62��6�   .��6�   
Lozinka:6�   �� 5*   
   -   5        $��
txtLozinka��5*      $��1��6$   $��1��61   $��5,5,5,5q�6A   $��2��6�   ��6R   �� $ korisnik.lozinka�$
	 True��6�   �� 5,   
   $��2��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��2��6c   $��26��6w   $��0q�6�   $��67��6�   .��6�   Ime:6�   �� 5-   
   -   5        $��txtIme��5-      $��2��6    $��1��6-   $��5,5,5,5q�6=   $��2��6�   ��6N   �� $ korisnik.ime�$
	 True��6�   �� 5/   
   $��3��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��2��6c   $��26��6w   $��0q�6�   $��66��6�   .��6�   
Prezime:6�   �� 50   
   -   5        $��
txtPrezime��50      $��3��6$   $��1��61   $��5,5,5,5q�6A   $��2��6�   ��6R   �� $ korisnik.prezime�$
	 True��6�   �� 52   
   $��4��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $��57��6z   .��6�   	Adresa:6�   �� 53   
   -   5        $��	txtAdresa��53      $��4��6#   $��1��60   $��5,5,5,5q�6@   $��2��6�   ��6Q   �� $ korisnik.adresa�$
	 True��6�   �� 55   
   $��5��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $
��auto��6z   $��2��6�   .��6�   Maternji jezik:6�   �� 56   
   -   5        $��txtMaternjiJezik��56      $��5��6*   $��1��67   $��5,5,5,5q�6G   $��2��6�   ��6X   �� $ korisnik.maternjiJezik�$
	 True��6�   �� 58   
   $��6��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $
��auto��6z   $��2��6�   .��6�   Ostali jezici:6�   �� 59   
   -   5        $��txtOstaliJezici��59      $��6��6)   $��1��66   $��5,5,5,5q�6F   $��2��6X   ��6l   �� $ korisnik.ostaliJezici�$
	 True��6�   �� 5;   
   $��7��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $��75��6z   .��6�   Broj kartice:6�   �� 5<   
   -   5        $��txtBrojKartice��5<      $��7��6(   $��1��65   $��5,5,5,5q�6E   $��2��6V   ��6j   �� $" korisnik.brojKreditneKartice�$
	 True��6�   �� 5>   
   $��8��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $��85��6z   .��6�   Broj telefona:6�   �� 5?   
   -	   5        $��txtBrojTelefona��5?      $��8��6)   $��1��66   $��5,5,5,5q�6F   $��2��6W   ��6k   �� $ korisnik.brojTelefona�$
	 True��6�   �� 5A   
   $��10��6   $��0��6   $
��Left=�6.   $��Center=�6I   $��26��6d   $��0q�6p   $
��auto��6{   $��2��6�   .��6�   	Zvanje:6�   �� 5B   
   -
   5        $��	txtZvanje��5B      $��10��6#   $��1��61   $��5,5,5,5q�6A   $��2��6S   ��6g   �� $ zvanje�$
	 True��6�   �� 5D   
   $��11��6   $��0��6   $
��Left=�6.   $��Center=�6I   $��26��6d   $��0q�6p   $
��auto��6{   $��2��6�   .��6�   
Diploma:6�   �� 5E   
   -   5        $��
txtDiploma��5E      $��11��6$   $��1��62   $��5,5,5,5q�6B   $��2��6T   ��6h   �� $ diploma�$
	 True��6�   �� 5G   
   $��9��6   $��0��6   $
��Left=�6-   $��Center=�6H   $��26��6c   $��0q�6o   $��57��6z   .��6�   Sertifikat:6�   �� 5H   
   -   5        $��txtSertifikat��5H      $��9��6'   $��1��64   $��5,5,5,5q�6D   $��2��6U   ��6i   �� $ 
sertifikat�$
	 True��6�   � 5J   
   $��12��6   $��2��6   $��Bottom=�6-   $��Right=�6H   $��40��6d   $	��120��6p    5K      �� 5L      6%   �� 5M      6%   .+�5O      �� -   5        
 ��Name$
 
btnPonisti��5O      $��0��6B   $��50��6R   $��30��6]   $��Right=�6i   $��5,5,5,5q�6�   .��6�   	Ponisti6�   �� 5P      -   5        $
 
btnSacuvaj��5P      $��1��6B   $��50��6R   $��30��6]   $��5,5,5,5q�6j   .��6{   	Sacuvaj6�   5Q      5S      5T      