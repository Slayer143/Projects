   M S B A M L   `   `   `  ����D  @Furniture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Furniture.PagesFurniture.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      "    Furniture.Pages.ShowMaterial   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Furniture.Pages     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     5      -   5          N�Name$  material��5
       N� Title$ Material and Hardware��6    N� 
Background
 �����.��5      � .+�5   
   �� $<��6Фильтр по категории качества:��6   $	��300��69   $��30��6E   
���   �$��20(�6d   {�.  $��227,45,873,624.2q�6�   �� 5   
   -   5         ��Name$ 	filterBox��5      
���   �$��30��69   $��20(�6E   $��532,45,517,624.2q�6S   6m   �� 5   
   -   5         ��Name$ counterBlock��5      
���   �$��30(�6=   {�.  $��1050,0,30,614.2q�6]   $	��320��6v   �� 5   
   -   5        $��3q�5      
�������
���   �$��30(�6O   $��
Назад��6]   $
��Left=�6m   $��	30,30,0,0q�6�   $	��Top=�6�   $	��130��6�   $��65��6�   6�   �� 5   
   -   5        $ pageName��5      
���   �
������� �� TextAlignment$ Center=�6L   $��15(�6c   $��Center=�6q   $��450,0,450,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��45��6�   $	��220��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   
�������$��30,130,30,50q�6(   .+�5      �� -   5         ��Name$ materialAndFurnitureList��5         
matFurList#���   69   $	��600��6p   $
��1325��6}   $��Stretch=�6�   $��Stretch=�6�    �� View 5      �� 5      .P�5      �� 	 �� Width$		 200��6Z   
 �� DisplayMemberBinding
 6)   ��  �� Path$ 
VendorCode�.��6f   Артикул6o   �� 5      $		 200��6T   
 6)   �� $
 Name�.��6`   Наименование6n   �� 5      $	 80��6X   
 6)   �� $ Quantity�.��6c   Количество6o   �� 5      $		 150��6T   
 6)   �� $
 Unit�.��6`   #!Единица измерения6s   �� 5      $		 150��6U   
 6)   �� $ Price�.��6a   Закупочная цена6r   �� 5      $		 250��6\   
 6)   �� $ SupplierName�.��6h   %#Основной поставщик6|   �� 5      $		 280��6[   
 6)   �� $ QualityName�.��6g   Качество6q   5       � 	Resources 5      "  System.Collections.ArrayList��%   &	          5       6$   5!      5"      5#      5$      5%      