   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CarService.ViewsCarService.Views  5      '    !CarService.Views.UpdateClientPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CarService.Views     5        N� Title$)  #Добавление клиента��5
       � DataContext 5      ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+.��5      ]� .+�5   
   �� -   5         ��Name$ headerLabel��5   C   $	��Top=�6   $)��#Добавление клиента��6&   $��26(�5      $
��Bold"�6   $��0 0 0 25q�6,   � 5   
   $��1��6   $��3��6    � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $��1* �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��40 �6    �� 5      $��1* �6    .+�5      �� $��ФИО:��6   $��Center=�6#   $
��Left=�6>   �� 5      -   5        $	��fio��5   &   $��1��6   $��10q�61   $��Center=�6>    !  MaterialDesignOutlinedTextBox#���   6u   ��6Y   �� *
Client.Fio+6u   �� 5      $��Город:��6   $��1��6%   $��Center=�62   $
��Left=�6M   �� 5      -   5        $
��city��5   3   $��1��6   $��10q�6&   $��1��6?   $��Center=�6i   #���   6�   ��6L   �� *Client.City+6�   �� 5       $��Адрес:��6   $��2��6%   $��Center=�62   $
��Left=�6M   �� 5!      -   5        $��address��5!   3   $��1��6   $��2��6&   $��10q�6b   $��Center=�6o   #���   6�   ��6B   �� *Client.Address+6�   �� 5"      $"��Номер телефона:��6   $��3��6.   $��Center=�6;   $
��Left=�6V   �� 5#      -   5        $��number��5#   3   $��1��6   $��3��6&   $��10q�6A   $��Center=�6�   #���   6�   ��6o   �� *Client.NumberPhone+6�   �� 5$      -   5        $��txtPlaceholderNumber��5$   1   $��1��6   $��3��6$   $��+70000000000��6N   
������  J� Opacity$	 0.5Q�6�    J� IsHitTestVisible$ False��6�   $��	10 10 0 0q�6�   $��15(�6�   �� 5%      $��E-mail:��6   $��4��6&   $��Center=�63   $
��Left=�6N   	 � Cursor$	  ��6i   �� 5&      -   5        $��email��5&   4   $��10q�6   $��1��6#   $��4��6   #���   6�   ��6a   �� *Client.Email+6�   �� 5'      -   5        $��txtPlaceholderEmail��5'   1   $��1��6   $��4��6$   $��email@address.com��6M   
������ $	 0.5Q�6�   $ False��6�   $��10 5 0 0q�6�   $��15(�6�   �� 5(      
 �� Orientation$
 
Horizontal=�6   $��Right=�62   $��5��6N   $��1��6[   .+�5)      �� -	   5        $��Сохранить��5)      $	��150��6-   
����  �$��1q�6`   �� 5*      -
   5        $��
Назад��5*      $	��150��6)   $	��5 0q�65    �� IsCancel$
 True��6Q   
����  �$��1q�6t   5+      5,      5.      5/      