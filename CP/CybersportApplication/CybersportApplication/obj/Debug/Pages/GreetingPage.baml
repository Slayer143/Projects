   M S B A M L   `   `   `  ����P  LCybersportApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CybersportApplication.PagesCybersportApplication.Pages  5      .    (CybersportApplication.Pages.GreetingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CybersportApplication.Pages     5        N� Title$  GreetingPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 	_myCanvas��5      $��3��6$   $��3��68   ��5      �� 5      -   5        _myBrush��5      5      �� 5   
   -   5         ��Name$ _registerButton��5      {�.   J� Opacity$ 0Q�6<   $��0,0.4,0,0.2q�6H   $��Register��6]   $��50(�6p   
����p��$��1��6�   
���   ���6�   �� *
GoRegister+�� 5   
   -   5        $ _authorizeButton��5      {�.  $ 0Q�6=   $��0,0.4,0,0.2q�6I   $��	Authorize��6^   $��50(�6r   
����p��$��1��6�   
���   �$��2��6�   ��6�   �� *GoAuth+6�   �� 5   
   -   5         ��Name$ _greetingBlock��5      $ 0Q�6,   $��10,74,10,63.6q�68   $��You are welcome��6O    �� TextAlignment$ Center=�6f   $��Center=�6}   $��65(�6�   
����p��$��3��6�   $��96��6�   �� 5   
   -   5        $ _actionBlock��5      $ 0Q�6*   $��1��66   $��10,43.4,10,46.2q�6F   $��Please choose the action��6_   $
��Wrap=�6   $ Center=�6�   $��50(�6�   
����p��$��1��6�   5      5       