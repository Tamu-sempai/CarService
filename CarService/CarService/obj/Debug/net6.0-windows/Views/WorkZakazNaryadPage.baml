   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CarService.ViewsCarService.Views  5      *    $CarService.Views.WorkZakazNaryadPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CarService.Views     5        N� Title$)  #Выполняемые работы��5       � DataContext 5      ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+.��5      ]� .+�5   
   �� $	��Top=�6   $��35(�6%   $
��Bold"�63   $)��#Выполняемые работы��6E   $��0 0 0 25q�6b   �� 5   
    �� Orientation$ 
Horizontal=�6   $��50��6.      SecondaryHueMidBrush#���   5      $	��Top=�5      .+�5      �� -   5        $��10 0 0 0q�5       % !MaterialDesignOutlinedLightButton#���  6'    � Cursor$
 Hand��6r   
����  �y�6�   ��  �� ElementName$ servicePage��   BooleanToVisibilityConverter �� 	Converter# [ .��5      �� $ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6.   $��25��6:      Kind$ NavigateBefore=�6E   $	��5 0q�6[   5      5      5      �� 5   
   $��Bottom=�6   #���   6,   .@�5      �� Показано �� 5      �6   �� *CurrentCount+ из �� 6<   �6@   �� *
TotalCount+ записей5      5      �� 5   
   ��5      �� 5      .R�5       � $��Disabled=�6    5!      .@�5#      �� ��6   �� *WorkZakazNaryads+��5$      �� 5%      .R�5&      �� $��2q�6!   
����  �	 �� CornerRadius$	 5��6H   ._�5'      � $	��800��6#   
 � ColumnDefinitions
 5(   "   �� 5)   &   .+�5+   "   �� $��7q�6-   $��1��68   .+�5,   &   �� $��22(�60   $
��Wrap=�6>   �� 5-      $��SemiBold"�6   $��Myanmar Text)�6O   �64   �� *	Work.Name+6O    �� 5.      $��Bahnschrift Light)�6S   �6   �� *
Work.Price+ �� StringFormat$ {0} руб.��6S   5/   '   50   #   51      52      54      56      57      58      59      