   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	   ;"clr-namespace:Messenger.ViewModelsMessenger.ViewModels  5   	        Messenger.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   #localclr-namespace:Messenger  5   	   +vm"clr-namespace:Messenger.ViewModels  5   	   -   5          � Title$  
MainWindow��5
   	   $	��600��6   $	��900��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�6(    � AllowsTransparency . ���#C0D58F � DataContext 5      (   "Messenger.ViewModels.MainViewModel  5   
   -   5        
MainVM��5      .��5      ]� .+�5   
   �� $	��Top=�6      WindowBorder#��[  5      5      o� 5a   
   ���#615e5e$	��Top=�6$   .@�5b      m� $��Application��6   
�������.@�5e      m� $��close��6   .  (System.Windows.Input.ApplicationCommands   Close m� Command# Z 5f      5h      5i      5j      � 5k   
    � ColumnDefinitions 5l      �� 5m      $	��270 �6#   �� 5n      .+�5p      � $��1��6   	 � RowDefinitions	 5q      �� 5r      $��80 �6$   �� 5s      �� 5t      $	��100 �6$   .+�5v      �� $��0��6   ._�5x      � $��Stretch=�6   $��10,0,0,0q�5y      .+�5z      �� $��20(�5{      $
��Bold"�5|      $��	10,10,0,0q�5}      $��Center=�5~      ��5z       �� *SelectedFriend.FirstName+5�      �� 5�      
 �� Orientation$
 
Horizontal=�6%   $��Right=�5�   !   .+�5�      "  FontAwesome.WPF.ImageAwesome     Icon$ VideoCamera=�6.   $��35��6A   $��0,0,10,0q�5�   *     5�      $ Phone=�6.   $��35��6;   $��0,0,10,0q�5�   *   5�      5�      5�      �� 5�      
������ $��1��5�      $��	10,0,10,0q�5�        	ChatStyle#��[ 5�      ��5�      �� *ChatWithUser+5�      � 5�      $��2��6    5�      �� 5�      6-   �� 5�      $��80 �6+   68   .+�5�      �� $��0��6   $��10,0,0,0q�5�        CustomTextBox#��[ 5�      .��5�      5�      �� 5�      $��1��6   $��45��6-   $��45��68   $��10q�6D   ��5�      �� 5�      .R�5�   "     $
 Send=�62   5�      5�      5�      5�      � 5�      $��0��6   	 5�      �� 5�      $��80 �6$   �� 5�      .+�5�      A�  A� Columns$ 2��6   .+�5�      �� $��Friends��6   $��Center=�5�      $��Black"�5�      $��15,0,0,0q�5�      �� 5�      -   5        $��70��5�      $��30��6(   
����� �$��30(�5�      ��5�      �� 5�       �� 
TargetType" ��6.   .R�5�   "   !  FontAwesome.WPF.FontAwesome     Icon$ 
PlusSquare=�61   5�   #   5�      5�      5�      �� 5�      $��1��6   
������   FriendListStyle#��[ 5�      ��5�      �� *	Friends+ �� SelectedItem 5�      �� *SelectedFriend+5�      5�      5�      5�      5�      