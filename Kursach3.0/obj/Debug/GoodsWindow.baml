   M S B A M L   `   `   `  ����E  AKursach3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Kursach3._0Kursach3._0  5   	       Kursach3._0.GoodsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Kursach3._0     5   	     � Title$  GoodsWindow��5   	   $	��450��6   $	��800��6*   $	��450��66   $	��800��6F   $	��450��6U   $	��800��6e   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.2* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��1.8* �6   �� 5      $
��2.5* �6   �� 5      $
��2.5* �6   �� 5      $
��1.5* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ UserNameLabel��5      $%��Имя пользователя��6'   $��Center=�6B   $��Center=�6f   $��Times New Roman)�6�   $��Center=�6�   $��Center=�6�   $	��151��6�   $��3��6�   $��1��6�   $��18(�6  �� 5   
   $)��#Мониторинг товаров��6   $��Center=�6-   $��Center=�6Q   $��Times New Roman)�6s   $��Center=�6�   $��Center=�6�   $	��443��6�   $��1��6�   $��2��6�   $��1��6�   $��28(�6  �� 5   
   -   5         ��Name$ listBox��5       �� SelectionMode$ Single=�6#   $��Center=�6:   $	��300��6W   $��Center=�6e   $	��599��6�   $��2��6�   $��1��6�   $��3��6�   $��2��6�   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $	��375��6%   $ Vertical=�61   .+�5      �� $��14(�6(   $
��Bold"�66   $
��Wrap=�6H   Наименование: �� 6k   �6o   �� *Title_Goods+6�   6�   �� 5       $
��Wrap=�6(   Категория: �� 6H   �6L   �� *Category.Title_Category+6w   6}   �� 5!      $
��Wrap=�6(   Поставщик: �� 6H   �6L   �� *Supplier.Title_supplier+6w   6}   �� 5"      $	��150��6(    �� TextAlignment$ Right=�64   *(Количество в наличии: �� 6a   �6e   �� *
In_Stock+6�   6�   5#      �� 5$      $	��150��6$   $ Right=�60   Стоимость: �� 6R   �6V   �� *Price+6o   6u   5%      5&      5(      �� 5)   
   -   5        $ ��Редактировать��5)      $��Center=�6)   $��Center=�6F   $��5��6a   $	��120��6n   $��40��6z   $��18(�6�   $��Times New Roman)�6�   6�   �� 5*   
   -   5         ��Name$ AddButtonGoods��5*      $��Добавить��6)   $��Center=�6<   $��Center=�6Y   $��1��6t   $��5��6�   $	��120��6�   $��40��6�   $��18(�6�   $��Times New Roman)�6�   6�   �� 5+   
   -   5        $ DeleteButton��5+      ���#ffa500$��Удалить��6<   $��Center=�6N   $��Center=�6k   $��5��6�   $��2��6�   $	��120��6�   $��40��6�   $��18(�6�   $��Times New Roman)�6�   {�.  6  �� 5,   
   -   5        	 ��Name$	 	SearchBox��5,      ���#ffa500$��Center=�6:   
 �� TextWrapping$

 Wrap=�6W   $�� ��6k   $��Bottom=�6s   $	��120��6�   $��1��6�   $��18(�6�   $��Times New Roman)�6�   $��20��6�   �� 5-   
   $��
Поиск��6   $��Center=�6    $��1��6=   $	��Top=�6J   �� 5.   
   -   5         ��Name$ PriceCheckBox��5.      $(��"Фильтрация по цене��6*   $��Center=�6G   $��2��6d   $��Bottom=�6q   6�   �� 5/   
   $��2��6   $��0��6"   $��2��62   $��0,52,0,0q�6C   .+�50      �� $��C��6   $��0��6    $��Center=�60   $��Center=�6N   $��20��6i   $��Center=�6t   $��Center=�6�   $��Times New Roman)�6�   �� 51      -   5        $	 	PriceBox1��51      ���#ffa500$��1��6>   $��Center=�6N   $��Center=�6k   $��20��6�   $��70��6�   $��18(�6�   $��Times New Roman)�6  {�6�   ��  �� ElementName$ 
PriceCheck�� �� Path$ 	IsChecked�6  �� 52      $
��По��6   $��2��6!   $��Center=�61   $��Center=�6O   $��30��6j   $��Center=�6u   $��Center=�6�   $��Times New Roman)�6�   �� 53      -	   5        $	 	PriceBox2��53      ���#ffa500$��3��6?   $��Center=�6O   $��Center=�6l   $��20��6�   $��70��6�   $��18(�6   $��Times New Roman)�6  {�6�   �� $ 
PriceCheck��$ 	IsChecked�6  54      �� 55   
   -
   5        $ ReportButton��55      $��3��6'   $��Отчёты��67   $��Center=�6H   $��Center=�6e   $��5��6�   $	��120��6�   $��40��6�   $��18(�6�   $��Times New Roman)�6�   6�   56      57      