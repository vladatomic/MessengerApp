   M S B A M L   `   `   `  ����P  LMessengerAppClientWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MessengerAppClientWpfMessengerAppClientWpf  5   	   &     MessengerAppClientWpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MessengerAppClientWpf     5   	     � Title$  Chitchat��5   	   $	��592��6   $	��425��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    � 	Resources 5	         CurrentUserPositionRight �� 
TargetType �� Triggers �� Binding �� Value �� Property	 �� Value  CurrentUserMessage  CurrentUserNickNameHidden��%B  &	        &	 �     &	 z    �� 5
   
   " ��61    5      �� 5       6   �� *ChatMemberNickName+ currentUser6E   .a�5      ��  � ��$	 Right=�6<   5      5      �� 5   
   " ��6+   .�5      ��  � ��
	 �����6/    5      �� 5       6"   �� *ChatMemberNickName+ currentUser6I   .a�5      ��  � ��
	 ��ح�67   5      5      �� 5   
   " ��62    5      �� 5       6   �� *ChatMemberNickName+ currentUser6E   .a�5      ��  � y�$	 Hidden=�63   5      5      5       .��5!      � -   5        $��primarni��5!      .+�5"   
   �� -   5        
 ��Name$
 label��5"      $��Enter Nickname :��6   $
��Left=�6:   $��	10,19,0,0q�6U   $	��Top=�6h    J� RenderTransformOrigin$ 0.339,-0.009&�6�   $	��121��6�   $��Calibri)�6�   $
��Bold"�6�   $��14(�6�   �� 5#   
   -   5         ��Name$ tBoxNickName��5#      $
��Left=�6(   $��26��6C   $��
136,19,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��127��6�   $��14(�6�   $��Calibri)�6�   $��Center=�6�   �� 5$   
   -   5         ��Name$ 	btnSignIn��5$      $��Sign In��6$   $
��Left=�66   $��
279,19,0,0q�6Q   $	��Top=�6e   $��81��6}   $��26��6�   $
��Bold"�6�   �� 5%   
   -   5        $
 label1��5%      $��	Message :��6    $
��Left=�64   $��
21,390,0,0q�6O   $	��Top=�6c   $
��Bold"�6{   $��Calibri)�6�   $��14(�6�   �� 5&   
   -   5        $ tBoxMessageText��5&      $
��Left=�6+   $��98��6F   $��
21,422,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��281��6�   $��16(�6�   $��Calibri)�6�   ���	#FF1148EE6�   �� 5'   
   -   5        $ btnPostMessage��5'      $
��Post��6)   $
��Left=�68   $��307,422,0,0q�6S   $	��Top=�6h   $��75��6�   $��14(�6�   $
��Bold"�6�   $��40��6�   �� 5(   
   -   5         ��Name$
 lBox��5(      $	��319��6!   $��
21,62,59,0q�6.   $	��Top=�6B   $��Stretch=�6r   $��Stretch=�6�   ���	#FF0F1C9E��6Z   �� ��5)      �� 5*      .R�5+      �� #��[  6!   .+�5,      �� $ tBoxItemNickName��6"   $��26��6<   $
 Wrap=�6H   $��0q�6�   $	��150��6�   $
��Left=�6�    �� 
IsReadOnly . #��[ 6�   $��11(�6  $��Calibri)�6  $��Center=�6+  ��6\   ��  �� Path$ ChatMemberNickName�6+  �� 5-      $ tBoxItemMessage��6"   $
��auto��6;   $
 Wrap=�6I   $��1q�6�   
����iA�$	��150��6�   $
��Left=�6�    . $��14(�6�   $��Calibri)�6�   $
��Bold"�6  #��[ 6  ��6]   �� $ ChatMemberMessage�.��6K  5.      5/      50      52      53      54      