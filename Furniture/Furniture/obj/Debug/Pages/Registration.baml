   M S B A M L   `   `   `  ����D  @Furniture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Furniture.PagesFurniture.Pages  5      "    Furniture.Pages.Registration   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Furniture.Pages     5      -   5          N�Name$  register��5	       N� Title$ Registration��6    N� 
Background
 �����.��5      � .+�5   
   �� -   5        $��3q�5      
�������
���   �$��30(�6O   $��
Назад��6]   $
��Left=�6m   $��	30,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   -   5         ��Name$ pageName��5      
���   �
������� �� TextAlignment$ Center=�6L   $��15(�6c   $
��Left=�6q   $��	582,0,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��45��6�   $	��220��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   -   5         ��Name$ 
nextButton��5      $��3q�6%   
�������
���   �$��30(�6c   $��
Далее��6q   $
��Left=�6�   $��1230,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   
�������$
��1100��6(   $��156,133,144,133.2q�65   .+�5      �� -   5        $
 info��5      $��51��6#   $��43��6.   $��23(�6:    �� Left$ 20��6H   
 �� Top$ 10��6Y   $��	ExtraBold"�6i   $ 0.918,0.753&�6�   ��5      �� 5      	 �� 
TargetType"	 ��6&   .R�5      � .+�5      A� 
�������65   �� 5      $��i��6$   $	��Top=�60   $��Center=�6O   5      5      
 � ToolTip
 5      _� 5      -   5         _�Name$ infoTip��5      
�������$��20(�6B   $+��%* - обязательные поля��6P   5      �� 5      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Фамилия��6X   $	��Top=�6g   $��41��6   $	��110��6�   $ 68��6�   $ 22��6�   �� 5      -   5         ��Name$ lastNameBox��5      $��2q�6+   $��25(�6?    �� TextAlignment$
 Left=�6M   $
��Left=�6b   $��43��6}    �� TextWrapping$ NoWrap=�6�   $#��Введите фамилию��6�   $	��Top=�6�   $	��215��6�   $ -0.934,2.424&�6�   $	 149��6�   $ 65��6  6!  �� 5      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Имя��6X   $	��Top=�6c   $��41��6{   $	��100��6�   $	 156��6�   $ 22��6�   �� 5       -   5        $
 name��5       $��2q�6$   $��25(�68   $
 Left=�6F   $
��Left=�6[   $��43��6v   $ NoWrap=�6�   $��Введите имя��6�   $	��Top=�6�   $	��215��6�   $ -0.934,2.424&�6�   $	 149��6�   $	 153��6  6  �� 5!      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Отчество��6X   $	��Top=�6h   $��41��6�   $	��110��6�   $	 236��6�   $ 22��6�   �� 5"      -	   5        $ secondNameBox��5"      $��2q�6-   $��25(�6A   $
 Left=�6O   $
��Left=�6d   $��43��6   $ NoWrap=�6�   $%��Введите отчество��6�   $	��Top=�6�   $	��215��6�   $ -0.934,2.424&�6�   $	 149��6  $	 236��6  6%  �� 5#      $��25(�6   $ Center=�6&   $
��Left=�6=   $:��4Подтвердите, что вы не робот*��6X   $	��Top=�6}   $��39��6�   $	��370��6�   $	 291��6�   $ 22��6�   �� 5$      -
   5        $ capture��5$      $��40(�6)   $ Center=�67   $
��Left=�6N   $�� ��6i   $	��Top=�6q   $��65��6�   $	��176��6�   $	 340��6�   $ 22��6�   �� 5%      -   5        $ captureCheck��5%      $��2q�6,   $��40(�6@   $
 Left=�6N   $
��Left=�6c   $��65��6~   $ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $	��176��6�   $ -0.934,2.424&�6�   $	 216��6�   $	 340��6  �� 5&      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Логин*��6X   $	��Top=�6f   $��41��6~   $	��100��6�   $ 70��6�   $	 426��6�   �� 5'      -   5        $ loginBox��5'      $��2q�6(   $��25(�6<   $
 Left=�6J   $
��Left=�6_   $��43��6z   $ NoWrap=�6�   $��Введите логин��6�   $	��Top=�6�   $	��212��6�   $ -0.934,2.424&�6�   $	 557��6�   $ 68��6  6  �� 5(      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Пароль*��6X   $	��Top=�6g   $��41��6   $	��100��6�   $	 156��6�   $	 426��6�   G� 5)      -   5         G�Name$ passwordBox��5)      $��25(�6/   $	 560��6=   $	 155��6O   $��41��6`   $	��212��6l   �� 5*      $��25(�6   $ Center=�6&   $
��Left=�6=   $��Повтор*��6X   $	��Top=�6g   $��41��6   $	��100��6�   $	 236��6�   $	 426��6�   G� 5+      -   5        $ passwordBoxRepeat��5+      $��25(�65   $	 560��6C   $	 236��6U   $��41��6f   $	��212��6r   �� 5,      $��25(�6   $ Center=�6&   $
��Left=�6=   $+��%Выберите фотографию��6X   $	��Top=�6s   $��41��6�   $	��345��6�   $	 318��6�   $	 426��6�   �� 5-      -   5        $ imageButton��5-      $��25(�6*   $��41��68   $	��345��6D   $	 426��6P   $	 363��6b   
�������$+��%Выбрать изображение��6�   6�   �� 5.      -   5         ��Name$ profileImage��5.      $	��337��6*   $	��296��67   $	 786��6C   $ 67��6U   $��Uniform=�6e   5/      50      51      