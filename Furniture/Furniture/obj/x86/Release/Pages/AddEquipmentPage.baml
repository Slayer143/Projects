   M S B A M L   `   `   `  ���� D  @Furniture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Furniture.PagesFurniture.Pages  &     Furniture.Pages.AddEquipmentPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:Furniture.Pages     -     N�Name$  addEquipment�� N� Title$ Adding�� N� 
Background
 �����.��� .+��� -   $��3q�
�������
���   �$��30(�$��
Назад��$
��Left=�$��	30,30,0,0q�$	��Top=�$	��130��$��65���� -   $��3q�
�������
���   �$��30(�$��Добавить��$
��Left=�$��1212,30,0,0q�$	��Top=�$	��148��$��65���� -    ��Name$ pageName��
���   �
������� �� TextAlignment$ Center=�$��15(�$��Center=�$��450,0,450,0q�$
��Wrap=�$	��Top=�$��45��$	��220�� J� RenderTransformOrigin$ 0.5,0.5&��� -   $ message��
���"�"�$��50��$��30(�$ Center=�$@��:Оборудование успешно добавлено��
 �� Top$ 52�� �� Left$ 10��$��426,45,426,604.2q��� 
�������$��121,133,121,32.2q�.+��� $��50��$	��250��$��30(�$ Center=�$��Маркировка��$ 52��$ 10���� $��50��$	��250��$��30(�$ Center=�$��Наименование��$	 152��$ 10���� $��50��$	��260��$��30(�$ Center=�$%��Тип оборудования��$	 252��$ 10���� $��50��$	��250��$��30(�$ Center=�$��Дата покупки��$	 352��$ 10���� -    ��Name$
 mark��$��50��$��30(�$	��269��$	 300��$ 52���� -   $
 name��$��50��$��30(�$	��269��$	 300��$	 152���� -   	 ��Name$	 types��$��50��$��30(�$	��269��$	 300��$	 252���� -	   $
 date��
 � 
InputScope$

 Date��$��30(�$��50��$	��274��$ 26��$	 407��&   System.Windows.Controls.Calendar  -
     Name$ calendar��$	 300��$	 331��$	��193��$	��269���� $��50��$	��269��$��30(�$ Center=�$"��Характеристика��$	 599��$ 10���� $��50��$	��258��$��30(�$ Center=�$��Значение��$	 874��$ 10���� $	 599��$	��472��$	��533��$ 52��.���� -    ��Name$ stack��.+��� -   $ 
firstStack�� �� Orientation$ 
Horizontal=�.+��� -   $ 	firstChar��$��50��$	��269��$��30(��� -   $ firstVal��$��50��$	��246��$��30(�