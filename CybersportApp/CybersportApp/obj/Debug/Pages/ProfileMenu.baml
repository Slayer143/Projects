   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      %    CybersportApp.Pages.ProfileMenu   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5        N� Title$  ProfileMenu��5	      .��5      � .+�5   
   �� $
��Back��6   
������ $��40(�69   
����U��$��2q�6a   
����p��$��10q�6�   y�6�   �� *AnotherUserVisibilityControl+{�6�   �� *AnotherUserIsEnabledControl+��6�   �� *Back+�� 5   
   $��Show details��6   
������ $��40(�6A   
����U��$��2q�6i   
����p��$��10q�6�   $��2��6�   y�6�   �� *%#AnotherUserDetailsVisibilityControl+{�6�   �� *$"AnotherUserDetailsIsEnabledControl+��6"  �� *ShowDetails+�� 5   
   $��Login��6   
����p��$��40(�65    �� TextAlignment$ Center=�6C   $��1��6Z   $
��10,0q�6g   �� 5   
   
����p��$��40(�6?   $��1��6M   $��1��6]   ��6   �� *Login+6]   �� 5   
   $��	Full name��6   
����p��$��40(�69   $ Center=�6G   $
��10,0q�6^   $��2��6l   �� 5   
   $
��Wrap=�6.   
����p��$��40(�6V   $��2��6d   $��1��6q   ��6   �� *
FullName+6q   �� 5   
   $��
Birth date��6   
����p��$��40(�6:   $ Center=�6H   $��5,0,10,0q�6_   $��3��6q   �� 5   
   
����p��$��40(�6C   $��1��6Q   $��3��6a   ��6   �� *	BirthDate+6a   �� 5   
   $��Country��6   
����p��$��40(�67   $ Center=�6E   $��4��6\   $
��10,0q�6i   �� 5   
   
����p��$��40(�6A   $��1��6O   $��4��6_   $��	0,0,395,0q�6l   $��2��6   ��6   �� *	Country+6   �� 5   
   $
��Team��6   
����p��$��40(�64   $ Center=�6B   $��5��6Y   $
��10,0q�6f   �� 5   
   
����p��$��40(�6>   $��1��6L   $��5��6\   ��6   �� *Team+6\   �� 5   
   $��40(�6�   $��5��6�   $��1��6�    �� Text 6   �� *Team+��6)   �� *TeamsCollection+y�6Q   �� *TeamChangeVisibilityControl+{�6�   �� *TeamChangeIsEnabledControl+6�   �� 5   
   $��Photo��6   
����p��$��40(�65   $ Center=�6C   $��1��6Z   $��2��6g   $��10q�6w   �� 5   
   $��2��6)   $��2��69   $��10q�6F   $��4��6R   ��6   �� *Photo+6R   �� 5   
   $��
Leave team��6   
������ $��40(�6?   
����U��
����p��$��2q�6|   $��1��6�   $��6��6�   $��10q�6-  ��6�   �� *	LeaveTeam+y�6�   �� *LeaveTeamVisibilityControl+{�6�   �� *LeaveTeamIsEnabledControl+6-  �� 5   
   $��Change photo��6   
������ $��40(�6A   
����U��
����p��$��2q�6~   $��2��6�   $��6��6�   $��10q�6  ��6�   �� *ChangePhoto+y�6�   �� *VisibilityControl+{�6�   �� *IsEnabledControl+6  �� 5   
   $��WriteMessage��6   
������ $��40(�6A   
����U��$��2q�6i   
����p��$��10q�6�   $��1��6%  y�6�   �� *AnotherUserVisibilityControl+{�6�   �� *AnotherUserIsEnabledControl+��6  �� *WriteMessage+6%  �� 5   
   $��Create team��6   
������ $��40(�6@   
����U��$��2q�6h   
����p��$��10q�6�   $��6��6&  y�6�   �� * ManagerCreateVisibilityControl+{�6�   �� *ManagerCreateIsEnabledControl+��6  �� *
CreateTeam+6&  �� 5    
   $��Change team��6   
������ $��40(�6@   
����U��$��2q�6h   
����p��$��10q�6�   $��6��6  $��1��6'  y�6�   �� *ManagerVisibilityControl+{�6�   �� *ManagerIsEnabledControl+��6�   �� *
ChangeTeam+6'  �� 5!   
   $
��Save��6   
������ $��40(�69   
����U��$��2q�6a   
����p��$��10q�6�   y�6�   �� *SaveVisibilityControl+{�6�   �� *SaveIsEnabledControl+��6�   �� *Save+�� 5"   
   $
��Save��6   
������ $��40(�69   
����U��$��2q�6a   
����p��$��10q�6�   $��6��6  y�6�   �� *SaveOtherVisibilityControl+{�6�   �� *SaveOtherIsEnabledControl+��6�   �� *	SaveOther+6  �� 5#   
   $��Invite to the team��6   $��40(�6.   
������ 
����p��$��2q�6j   
����U��$��2��6�   $��6��6�   $��10q�6�   y�6�   �� *InviteVisibilityControl+{�6�   �� *InviteIsEnabledControl+��6  �� *Invite+�� 5$   
   $��Admin options��6   
������ $��40(�6B   
����U��$��2q�6j   
����p��$��10q�6�   $��2��6�   y�6�   �� *AdminVisibilityControl+{�6�   �� *AdminIsEnabledControl+��6	  �� *AdminOptions+�� 5%   
   $��Delete my profile��6   
������ $��40(�6F   
����U��$��2q�6n   
����p��$��
10,15,10,5q�6�   $��1��6"  y�6�   �� *DeleteVisibilityControl+{�6�   �� *DeleteIsEnabledControl+��6  �� *Delete+6"   � ColumnDefinitions 5'   
   �� 5(      �� 5)      �� 5*       � RowDefinitions 5,   
   �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      55      56      