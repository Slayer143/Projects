   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 67   '    !CybersportApp.Pages.TeamsViewPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     67     N� Title$  TeamsViewPage��5	      .��5      � .+�5   
   �� $��10,10,10,10.6q�6   $��Add team��6(   $��30(�6�   
���   �
����p��
����2��$��2q�6�   $��0��6  $��3��6  y�6;   �� *AddVisibilityControl+{�6g   �� *AddIsEnableControl+��6�   �� *	AddTeam+6  �� 5   
   $��10,12.4,10,10.2q�6   $��1��6-   $��40(�6:   
����p��
������ $��Find by name:��6u    �� TextAlignment$ Center=�6�   �� 5   
   $��1��6   $��10,9.4,10,10.2q�6"   $��1��6:   $��40(�6G   
����p��
������  �� TextWrapping$
 Wrap=�6�   
����2��$��2q�6�   ��6�   �� *Finder+6�   �� 5   
   $��2��6   $��10,9.4,10,10.2q�6!   $��1��69   
������ $��40(�6_   
����U��
����2��$��2q�6�   $
��Find��6�   ��6�   �� *	UseFinder+6�   �� 5   
   $��10,7.8,10,10q�6   $��2��6)   $��20(�6X   $��3��6f   ��66   �� *	TeamsList+ �� View 5      �� 5      .P�5      ��  �� Width$	 300��6P    �� DisplayMemberBinding 6%   ��  �� Path$
 Name�.��6\   Name6b   �� 5      $	 300��6U    6%   �� $ 	ShortName�.��6a   
Short name6m   �� 5      $	 300��6V    6%   �� $ 
Discipline�.��6b   
Discipline6n   �� 5      $	 300��6S    6%   �� $ Country�.��6_   	Country6h   5      5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5        � RowDefinitions 5#   
   �� 5$      ��6   �� *AddRowHeight+�� 5%      $
��0.3* �6   �� 5&      ��6   �� *LastRowHeight+5(      5)      