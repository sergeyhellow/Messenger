   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   GradientBtn �� Property �� Value �� 
StartPoint �� EndPoint � Color � Offset �� Triggers :� RoutedEvent	 ��Name
 �� 
TargetName �� TargetProperty �� From	 �� To g� Duration g� AutoReverse g� RepeatBehavior W� From	 W� To �� BeginStoryboardName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      .R�5      � .+�5	      �� ��5
      �� 5   "   $	 0,0&�66   $	 1,1&�6G   .��5   &   � 	grad1��$	 red��6B   $ 0Q�6N   6[   � 5   &   	grad2��$ Orange��6B   $
 0.25Q�6Q   6a   � 5   &   	grad3��$ Purple��6B   $
 0.50Q�6Q   6a   � 5   &   	grad4��$ Brown��6B   $
 0.75Q�6P   6`   5   #   5      5       5      :� 5      $ Button.Click��6'   .[�5      �� $	 gradient��6.   .��5   "   �� .��5   &   �� $
 grad1��65   $ Color�5   5   $	 RedX�5   5   $ OrangeX�6@   $ 0:0:10D�5   5    . $ Forever��5   5   5   '   �� 5    &   $
 grad2��66   $ Color�5!   5   $ PurpleX�5"   5   $ BrownX�6C   $ 0:0:10D�5#   5    . $ Forever��5$   5   5(   '   W� 50   &   $
 grad4��66   $ Offset�51   6   $
 0.75X�52   6   $ 0X�6B   $ 0:0:5D�53   6    . $ Forever��54   6   58   '   5:   #   5;      5<      :� 5>      $ Button.MouseLeave��6'   .[�5?      �� $ gradient��6-   5A      5C      5F      5H      5I      5L      