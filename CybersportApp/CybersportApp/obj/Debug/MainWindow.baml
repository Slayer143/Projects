   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CybersportAppCybersportApp  5   	       CybersportApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CybersportApp     5   	   -   5          �Name$  cybersportMainWindow��5   M    � Title$ 
MainWindow��6	   $	��730��6   $
��1200��6)   
�������.��5	      � .+�5
   
    � -   5          �Name$ 	baseFrame��5
        � NavigationUIVisibility$ Hidden=�6Q   $��0,0,-0.4,0.4q�6q   {�6#   �� *GeneralIsEnabledControl+��6�   �� *ColumnRange+��6�   �� *ColumnPosition+��6�   �� *RowPosition+�� 5   
   $$��Are you sure you want to exit?��6    �� TextAlignment$ Center=�6�   
����2��$
��Bold"�6�   $��30(�6�    �� Left$ 10��6�   
 �� Top$ 10��6�   $��212.6,10,213.6,43q�6  $��1��6  y�6:   �� *ExitVisibilityControl+{�6g   �� *ExitIsEnableControl+6  �� 5   
   $	��Yes��6�   
����p��$��2q�6�   
���   �
����2��$��40(�6�   $ 10��6�   $	 120��6  $��1��6  $��9.6,43,756.6,10q�6#  ��6   �� *Exit+y�6*   �� *ExitVisibilityControl+{�6W   �� *ExitIsEnableControl+6#  �� 5   
   $��No��6�   
����p��$��2q�6�   
���   �
����2��$��40(�6�   $	 666��6�   $	 123��6  $��1��6  $��756.6,44,9.6,9q�6'  ��6   �� *
DenyExit+y�6.   �� *ExitVisibilityControl+{�6[   �� *ExitIsEnableControl+6'  �� 5   
   $
��Exit��6o   $��60(�6~   $��	0,0,0.4,0q�6�   
����2��
���   �
���� ��$��2q�6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *ExitAgreement+6  �� 5   
   $��
My profile��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��1��6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *GoToProfile+6  �� 5   
   $��
View users��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��2��6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *	GoToUsers+6  �� 5   
   $��
View teams��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��3��6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *	GoToTeams+6  �� 5   
   $��View tournaments��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��4��6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *GoToTournaments+6  �� 5   
   $��My messages��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��5��6
  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *GoToMessages+6
  �� 5   
   $��View my detailed info��6o   $��30(�6�   $��	0,0,0.4,0q�6�   
����U��
���� ��$��2q�6�   $��6��6  {�6   �� *GeneralIsEnabledControl+y�6?   �� *GeneralVisibilityControl+��6�   �� *GoToDetails+6  ��5   
   �� 5       �� ImageSource 6   �� *BackgroundImage+ � RowDefinitions 5   
   �� 5      �� 5      ��6   �� *	RowHeight+�� 5      ��6   �� *	RowHeight+�� 5      ��6   �� *	RowHeight+�� 5       ��6   �� *	RowHeight+�� 5!      ��6   �� *	RowHeight+�� 5"      ��6   �� *LastRowHeight+	 � ColumnDefinitions	 5$   
   �� 5%      ��6   �� *FirstColumnWidth+�� 5&      $��3* �6   5(      5)      