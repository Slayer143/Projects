   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      -    'CybersportApp.Pages.TournamentsViewPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5        N� Title$  TournamentsViewPage��5	      .��5      � .+�5   
   �� $��10,10,10,10.4q�6   $��Add tournament��6(   $��30(�6�   
���   �
����p��
����2��$��2q�6  $��0��6  $��3��6'  y�6A   �� *AddVisibilityControl+{�6m   �� *AddIsEnableControl+��6�   �� *AddTournament+6'  �� 5   
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
   $��10,9.8,10,10q�6   $��20(�6Q   $��2��6_   $��3��6l   ��6)   �� *TournamentsList+ �� View 5      �� 5      .P�5      ��  �� Width$	 180��6P    �� DisplayMemberBinding 6%   ��  �� Path$
 Name�.��6\   Name6b   �� 5      $	 160��6U    6%   �� $ 	PrizePool�.��6a   
Prize pool6m   �� 5      $	 160��6V    6%   �� $ 
FirstPlace�.��6b   First place prize6u   �� 5      $	 160��6W    6%   �� $ SecondPlace�.��6c   Secon place prize6v   �� 5      $	 160��6V    6%   �� $ 
ThirdPlace�.��6b   Third place prize6u   �� 5      $	 150��6U    6%   �� $ 	StartDate�.��6a   
Start date6m   �� 5      $	 150��6S    6%   �� $ EndDate�.��6_   
End date6i   �� 5      $	 100��6X    6%   �� $ Participants�.��6d   Participants6r   �� 5      $	 130��6Z    6%   �� $ TournamentType�.��6f   Type6l   �� 5      $	 150��6V    6%   �� $ 
Discipline�.��6b   
Discipline6n   5      5!       � ColumnDefinitions 5#   
   �� 5$      �� 5%      �� 5&       � RowDefinitions 5)   
   �� 5*      ��6   �� *AddRowHeight+�� 5+      $
��0.3* �6   �� 5,      ��6   �� *LastRowHeight+5.      5/      