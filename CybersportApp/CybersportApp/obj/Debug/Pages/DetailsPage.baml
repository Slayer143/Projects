   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      %    CybersportApp.Pages.DetailsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5        N� Title$  DetailsPage��5	      .��5      � .+�5   
   ��  �� TextAlignment$ Center=�6   $��You entered wrong data��6+   $
��Wrap=�6~   
���  ��$��40(�6�   $��1��6�   $��10q�6�   $��2��6�   y�6I   �� *ErrorMessageVisibilityControl+6�   �� 5   
   $ Center=�6   $0��*Now you can add or change your information��6+   $
��Wrap=�6�   
����p��$��40(�6�   $��2��6�   $��0,0,10,0q�6�   $��2��6�   y�6]   �� *UpdateVisibilityControl+6�   �� 5   
   $ Center=�6   $��Raiting��6+   
����p��$��40(�6N   $��10,10,10,28.2q�6\   $��3��6s   �� 5   
   $��1��6,   $��10,10,10,28.2q�6<   $��3��6T   
����p��$��40(�6u   ��6   �� *Rating+6u   �� 5   
   $��1��6   $��3��6#   $��10,10,10,28.2q�60    �� Text 6G   �� *Rating+��6_   �� *	Ratings+y�6   �� *UpdateVisibilityControl+{�6�   �� *IsEnabledControl+�� 5   
   $��Verify my account��6   $��40(�6-   
������ 
����p��$��2q�6i   
����U��$��2��6�   $��2��6�   $��10q�6�   y�6�   �� *VerifyVisibilityControl+{�6�   �� *VerifyIsEnabledControl+��6  �� *Verify+�� 5   
   $ Center=�6   $��Account status��6+   
����p��$��40(�6U   $��10,10,10,29q�6c   $��2��6x   �� 5   
   $��1��63   $��10,10,10,29q�6C   $��2��6X   
����p��$��40(�6y   ��6   �� *AccountStatus+6y   �� 5   
   $ Center=�6   $��Total earnings��6+   
����p��$��40(�6U   $��10,9.8,10,30.4q�6c   $��4��6{   �� 5   
   $��1��6X   $��10,9.8,10,30.4q�6h   $��4��6�   
����p��$��40(�6�   $��2q�6�   
����p��
������ ��6   �� *TotalEarnings+{�61   �� *IsEnabledControl+6�   �� 5   
   $ Center=�6   $��Year of career start��6+   
����p��$��40(�6[   $��10,9.6,10,29.6q�6i   $��5��6�   �� 5   
    �� 	MaxLength$ 4��6V   $��1��6d   $��10,9.6,10,29.6q�6t   $��5��6�   
����p��$��2q�6�   
����p��$��40(�6�   
������ ��6   �� *CareerStart+{�6/   �� *IsEnabledControl+6�   �� 5   
   $ Center=�6   $��
Discipline��6+   
����p��$��40(�6Q   $��10,10.4,10,28.8q�6_   $��6��6x   �� 5   
   $��1��60   $��10,11.4,10,28.8q�6@   $��6��6Z   
����p��$��40(�6{   ��6   �� *
Discipline+6{   �� 5   
   $��1��6   $��6��6#   $��10,9.4,10,29.8q�60    6H   �� *
Discipline+��6d   �� *Disciplines+y�6�   �� *UpdateVisibilityControl+{�6�   �� *IsEnabledControl+�� 5   
   $
��Save��6   $��40(�6    
������ 
����p��$��2q�6\   
����U��$��2��6�   $��7��6�   $��10,10.2,10,10q�6�   y�6�   �� *UpdateVisibilityControl+{�6�   �� *IsEnabledControl+��6  �� *Save+�� 5   
   $��Edit information��6   $��40(�6,   
������ 
����p��$��2q�6h   
����U��$��7��6�   $��10,10.2,10,10q�6�   ��6�   �� *Edit+y�6�   �� *EditVisibilityControl+{�6   �� *EditIsEnabledControl+�� 5   
   $��Cancel��6   $��40(�6"   
������ 
����p��$��2q�6^   
����U��$��1��6�   $��7��6�   $��10,10.2,10,10q�6�   y�6�   �� *UpdateVisibilityControl+{�6�   �� *IsEnabledControl+��6  �� *Cancel+�� 5   
   $
��Back��6   
������ $��40(�69   
����U��$��2q�6a   
����p��$��10q�6�   y�6�   �� *AnotherUserVisibilityControl+{�6�   �� *AnotherUserIsEnabledControl+��6�   �� *Back+�� 5!   
   $ Center=�6   $��Achievements��6+   
����U��
������ $��40(�6r   $��10,30,10,10q�6�   $��3��6�   $��2��6�   y�6�   �� *AchievementsVisibilityControl+{�6�   �� *AchievementsIsEnabledControl+�� 5#   
   $��10q�6   $��4��6   $��20(�6U   $��2��6c   $��2��6s   ��6,   �� *AchievementsList+y�6�   �� *AchievementsVisibilityControl+{�6�   �� *AchievementsIsEnabledControl+ �� View 5$      �� 5%      .P�5&      ��  �� Width$	 250��6Z    �� DisplayMemberBinding 6%   ��  �� Path$ TournamentName�.��6f   
Tournament6r   �� 5'      $	 130��6Q    6%   �� $ Place�.��6]   Place6d   5(      5*      �� 5+   
   $��Add achievement��6   $��40(�6+   
������ 
����p��$��2q�6g   
����U��$��2��6�   $��6��6�   $��10,10.4,10,9.8q�6�   y�6�   �� *!AddAchievementVisibilityControl+{�6  �� * AddAchievementIsEnabledControl+��66  �� *GoToAddAchievement+ � ColumnDefinitions 5-   
   �� 5.      �� 5/      �� 50      	 � RowDefinitions	 52   
   �� 53      �� 54      �� 55      �� 56      �� 57      �� 58      �� 59      �� 5:      5<      5=      