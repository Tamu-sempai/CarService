   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CarService.ViewsCarService.Views  5      ,    &CarService.Views.UpdateZakazNaryadPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CarService.Views     5        N� Title$?  9Добавление нового заказ-наряда��5
       � DataContext 5      ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+.��5      �� .+�5   
   �� -   5         ��Name$ headerLabel��5   O   $	��Top=�6   $?��9Добавление нового заказ-наряда��6&   $��26(�5      $
��Bold"�6   $��0 0 0 25q�6,   � 5   
   $	��400��6   $	��800��6   $��	0 100 0 0q�6(    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��1* �6#    � RowDefinitions 5      �� 5      $��70 �6    �� 5      $��70 �6    �� 5      $��70 �6    �� 5      $��1* �6    .+�5      �� $��Клиент:��6   $��Center=�6&   $
��Left=�6A   $��18(�6\   �� 5      -   5        $��client��5   3   $��50��6   $��1��6#   $��10q�6A   $��Center=�5       "  MaterialDesignOutlinedComboBox#���   5      ��5   2   �� *	Clients+ �� SelectedItem 5      �� *Client+��5      �� 5      .R�5       �� �� 5!      �6"   �� *Fio+5"      5#      5%      �� 5&      $��Автомобиль:��6   $��18(�6*   $��1��68   $��Center=�6E   $
��Left=�6`   $��0 5 0 0q�6{   �� 5'      -   5        $
��auto��5'   M   $��50��6   $��1��6#   $��1��63   $��10q�6@   $��0 5 0 0q�6�   $��Center=�6�   #���   6�   ��6Y   �� *
CarClients+ 6|   �� *	CarClient+��5(      �� 5)      .R�5*      �� �� 5+      �6"   �� *Marka+ �� 5,      �6"   �� *Model+ - �� 5-   !   �6%   �� *
Client.Fio+5.      5/      51      �� 52      $1��+Дата окончания ремонта:��6   $��18(�66   $��2��6D   $��Center=�6Q   $
��Left=�6l    � Cursor$  ��6�   $��0 5 0 0q�6�   (  "System.Windows.Controls.DatePicker  53      -   5        	  Name$	 serviceDatePicker��53   j   $��50��6   $��18(�6%   
   IsTodayHighlighted$

 True��63   $��1��6M   $��2��6]   6j   �� 54       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��10��6N   $��1��6\   .+�55      �� -   5        $��
Далее��55      $	��150��6)   
����  �$��1q�6U   �� 56      -   5        $��
Назад��56      $	��150��6)   $	��5 0q�65    �� IsCancel$
 True��6Q   
����  �$��1q�6t   57      58      59      5:      