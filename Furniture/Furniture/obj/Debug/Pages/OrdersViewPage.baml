   M S B A M L   `   `   `  ����D  @Furniture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Furniture.PagesFurniture.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      $    Furniture.Pages.OrdersViewPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Furniture.Pages     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     5      -   5          N�Name$  orders��5
       N� Title$ 	My orders��6    N� 
Background
 �����.��5      � .+�5   
   �� -   5        $��3q�5      
�������
���   �$��30(�6O   $��
Назад��6]   $
��Left=�6m   $��	30,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   -   5         ��Name$ deleteButton��5      $y�Hidden=�6'   $��3q�6;   
���  ��
���   �$��30(�6s   $��Удалить��6�   $
��Left=�6�   $��1240,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   -   5        $ cancelButton��5      $y�Hidden=�6'   $��3q�6;   
�������
���   �$��30(�6y   $��Отменить��6�   $
��Left=�6�   $��
583,50,0,0q�6�   $	��Top=�6�   $	��220��6�   �� 5   
   -   5         ��Name$ pageName��5      
���   �
������� �� TextAlignment$ Center=�6L   $��15(�6c   $��Center=�6q   $��450,0,450,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��45��6�   $	��220��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   
�������$��30,130,30,50q�6(   .+�5      �� -   5         ��Name$ 
ordersList��5         _ordersList#���   6+   $	��600��6c   $
��1325��6p   $��Stretch=�6}   $��Stretch=�6�    �� View 5      �� 5      .P�5      �� 	 �� Width$		 150��6[   
 �� DisplayMemberBinding
 6)   ��  �� Path$ OrderNumber�.��6g   Номер заказа6u   �� 5      $		 150��6Y   
 6)   �� $ 	OrderDate�.��6e   Дата заказа6r   �� 5      $		 200��6Y   
 6)   �� $ 	OrderName�.��6e   Название заказа6v   �� 5      $		 200��6[   
 6)   �� $ ProductName�.��6g   #!Название продукта6z   �� 5      $		 130��6X   
 6)   �� $ Customer�.��6d   Заказчик6n   �� 5      $		 130��6W   
 6)   �� $ Manager�.��6c   Менеджер6m   �� 5      $		 120��6U   
 6)   �� $ Price�.��6a   
Цена6g   �� 5      $		 150��6\   
 6)   �� $ CompleteDate�.��6h   Дата выполнения6y   �� 5      $		 100��6V   
 6)   �� $ Status�.��6b   Статус6j   5       � 	Resources 5       "  System.Collections.ArrayList��%   &	          5!      6$   5"      5#      5$      �� 5%   
   -   5         ��Name$ agreementMessage��5%      $y�Hidden=�6+   
�������$��395,225,405,225.2q�6S   .+�5&      �� $��76��6    �� Left$	 140��6$   
 �� Top$ 34��66   $	��330��6F   $��30(�6R   $
��Wrap=�6`   $T��NВы уверены что хотите сохранить изменения?��6t   �� 5'      -   5        $ agreeButton��5'      $
��Да��6*   $y�Hidden=�67   $��30(�6K   
���"�"�$��50��6r   $	��100��6~   $	 140��6�   $	 168��6�   6�   �� 5(      -	   5        $ anotherAgreeButton��5(      $
��Да��61   $y�Hidden=�6>   $��30(�6R   
���"�"�$��50��6y   $	��100��6�   $	 140��6�   $	 168��6�   6�   �� 5)      -
   5        $��Нет��5)      $��30(�6#   
���P��$��50��6D   $	��100��6P   $	 370��6\   $	 168��6n   6   5*      5+      5,      