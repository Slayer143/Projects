   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      +    %CybersportApp.Pages.AuthorizationPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5      -   5          N�Name$  AuthPage��5	   !    N� Title$ AuthorizationPage��6   .��5      � ��5   
   �� 5       �� ImageSource 6   �� *BackgroundImage+ � RowDefinitions 5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��Back��6   $��50(�6    
����2��
���   �$��10,20,330,237.4q�6r   ��6.   �� *Back+6r   �� 5   
   $��Accept��6   $��50(�6"   
����2��
���   �$��330,20,10,237.4q�6y   $��1��6�   ��60   �� *	CheckUser+6�   �� 5   
    �� TextAlignment$ Center=�6   $
��Wrap=�6+   $��60(�6?   
����U��$��220,143,156,107.4q�6�   $��2��6�   ��6g   �� *SystemMessage+6�   �� 5   
   $��1��6   $ Center=�6&   $��Login��6=   $��40(�6J   $��1��6X   $��220,268,10,10.4q�6l   �� 5   
   $ Center=�6   $��Password��6+   $��40(�6;   $��1��6I   $��220,9.6,10,268q�6]   $��1��6u   �� 5   
   
���   �$��40(�6I   
�������
����p��$��2q�6   $��10,268,156,10.4q�6�   $��1��6�   ��6%   �� *Login+ �� Mode$ TwoWay=�6�   �� 5   
   
���   �$��40(�6L   
����p��
�������$��2q�6�   $��1��6�   $��10,9.6,156,267q�6�   $��1��6�   ��6%   �� *
Password+$ TwoWay=�6�   5      5      