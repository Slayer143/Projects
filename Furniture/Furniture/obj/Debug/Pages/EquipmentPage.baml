   M S B A M L   `   `   `  ����D  @Furniture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Furniture.PagesFurniture.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      #    Furniture.Pages.EquipmentPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Furniture.Pages     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     5      -   5          N�Name$  	equipment��5
       N� Title$ 	Equipment��6    N� 
Background
 �����.��5      � .+�5   
   �� -   5        $��3q�5      
�������
���   �$��30(�6O   $��
Назад��6]   $
��Left=�6m   $��	30,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   -   5         ��Name$ pageName��5      
���   �
������� �� TextAlignment$ Center=�6L   $��15(�6c   $��Center=�6q   $��450,0,450,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��45��6�   $	��220��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   
�������$��30,130,30,50q�6(   .+�5      �� -   5         ��Name$ equipmentList��5       
  eqList#���   6.   $	��499��6a   $
��1320��6n    �� Left$ 10��6{   
 �� Top$ 10��6�   	 �� View	 5      �� 5      .P�5      �� 
 �� Width$	
 200��6V    �� DisplayMemberBinding 6)   ��  �� Path$ Number�.��6b   Маркировка6n   �� 5      $	
 200��6T    6)   �� $
 Name�.��6`   Наименование6n   �� 5      $	
 200��6T    6)   �� $
 Type�.��6`   !Тип оборудования6r   �� 5      $	
 720��6W    6)   �� $ CharVal�.��6c   Характеристики6s   5       � 	Resources 5      "  System.Collections.ArrayList��%   &	          5      6$   5      5      5      5      5       