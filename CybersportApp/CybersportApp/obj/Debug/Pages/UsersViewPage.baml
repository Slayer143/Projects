   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      '    !CybersportApp.Pages.UsersViewPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5        N� Title$  UsersViewPage��5	      .��5      � .+�5   
   �� $��10,13,10,9.6q�6   $��40(�6*   
����p��
������ $��Find by login:��6e    �� TextAlignment$ Center=�6{   �� 5   
   $��1��6   $��10,13,10,6.6q�6"   $��40(�68   
����p��
������  �� TextWrapping$
 Wrap=�6�   
����2��$��2q�6�   ��6s   �� *Finder+6�   �� 5   
   $��2��6   $��10,13,10,6.6q�6!   
������ $��40(�6P   
����U��
����2��$��2q�6�   $
��Find��6�   ��6�   �� *	UseFinder+6�   �� 5   
   -   5         ��Name$
 view��5      $��10,9.4,10,10q�6!   $��1��67   $��20(�6f   $��2��6�   $��3��6�   ��6D   �� *	UsersList+ �� View 5      �� 5      .P�5      ��  �� Width$	 180��6Q    �� DisplayMemberBinding 6%   ��  �� Path$ Login�.��6]   Login6d   �� 5      $	 180��6T    6%   �� $ FullName�.��6`   	Full name6k   �� 5      $	 180��6U    6%   �� $ 	BirthDate�.��6a   
Birth date6m   �� 5      $	 180��6S    6%   �� $ Country�.��6_   	Country6h   �� 5      $	 180��6P    6%   �� $
 Role�.��6\   Role6b   �� 5      $	 180��6P    6%   �� $
 Team�.��6\   Team6b   5      5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       	 � RowDefinitions	 5#   
   �� 5$      $
��0.3* �6   �� 5%      $
��1.7* �6   5'      5(      