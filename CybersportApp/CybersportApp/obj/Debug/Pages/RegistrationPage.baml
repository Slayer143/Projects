   M S B A M L   `   `   `  ����H  DCybersportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CybersportApp.PagesCybersportApp.Pages  5      *    $CybersportApp.Pages.RegistrationPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CybersportApp.Pages     5        N� Title$  RegistrationPage��5	      .��5      � ��5   
   �� 5       �� ImageSource 6   �� *BackgroundImage+ � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��233.6 �6   �� 5      $��232.8 �6   �� 5      $��233.6 �6   .+�5   
   �� $
��Back��6   $��50(�6    
����2��
���   �$��70,20,70,143.6q�6r   ��6.   �� *Back+6r   �� 5   
   $��Fill in the form below��6   
����p��$��40(�6F    �� TextAlignment$ Center=�6T   $��10,0,10,163.6q�6k   $��1��6�   �� 5   
   $��Accept��6   $��50(�6A   
����2��
���   �$��70,20,70,143.6q�6z   $��2��6�   ��6"   �� *
AcceptForm+6�   �� 5   
   
������ 
����p��$��2q�6\   
���   �$��40(�6�   $��Choose photo��6�   $��10,156,10,8.6q�6�   $��1��6�   $��1��6�   ��6   �� *
GetImage+6�   �� 5   
   $��Login��6   $ Center=�6!   
���   �$��40(�6K   $��0,156,10,9.6q�6Y   �� 5    
   
����U��$��30(�6,   
����p��$��2q�6f   
���   �$��10,23.4,0,156.4q�6�   $��1��6�   ��6:   �� *Login+6�   �� 5!   
   $��Password��6   $ Center=�6$   
���   �$��40(�6N   $��0,83.4,10,81.4q�6\   $��1��6t   �� 5"   
   
����U��$��30(�6,   
����p��$��2q�6i   
���   �$��10,169.4,0,10.4q�6�   $��1��6�   ��6:   �� *
Password+6�   �� 5#   
   $��Country��6   $ Center=�6#   
���   �$��40(�6M   $��0,9.6,10,165q�6[   $��2��6q   �� 5$   
   
���   �
����U��$��30(�6@   
����p��$��2q�6�   $��10,97.6,0,81q�6�   $��2��6�   ��6N   �� *	Countries+ �� Text 6p   �� *	Country+6�   �� 5%   
   $��	Last Name��6   $ Center=�6%   
���   �$��40(�6O   $��10,156,10,9.6q�6]   $��2��6t   �� 5&   
   
����U��$��30(�6,   
����p��$��2q�6i   
���   �$��0,23.4,10,156.4q�6�   $��2��6�   $��1��6�   ��6:   �� *
LastName+6�   �� 5'   
   $
��Name��6   $ Center=�6    
���   �$��40(�6J   $��10,83.4,10,81.4q�6X   $��2��6q   $��1��6�   �� 5(   
   
����U��$��30(�6,   
����p��$��2q�6e   
���   �$��0,169.4,10,10.4q�6�   $��2��6�   $��1��6�   ��6:   �� *Name+6�   �� 5)   
   $��
Birth date��6   $ Center=�6&   
���   �$��40(�6P   $��10,9.6,10,165q�6^   $��2��6u   $��2��6�   (  "System.Windows.Controls.DatePicker  5*   
   
����p��$��2q�6R   $��40(�6f   
���   �$��0,97.6,0,81q�6�   $��2��6�   $��2��6�      Text 6   �� *	BirthDate+ �� Mode$ TwoWay=�6�   �� 5+   
   $��Uniform=�6   $��1��6"   $��27,10.4,27,165q�62   $��2��6J   $��1��6{   ��6[   �� *ImageContent+6{   �� 5,   
   $
��I am��6   
���   �$��40(�63   $��10,70,308,94.6q�6A   $��1��6Y   �� 5-   
   
���   �
����U��$��30(�6@   
����p��$��2q�6�   $��97,75,10,108.6q�6�   $��1��6�   ��6N   �� *Roles+ 6l   �� *Role+6�   5.      5/      