   M S B A M L   `   `   `  ����H  DMachineVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MachineVision.ViewsMachineVision.Views  5      "    MachineVision.Views.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      -local!clr-namespace:MachineVision.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5
        � Title$  MainView��5      $
��1200��5      $	��800��5      ! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp2=�6      Mode$ PrimaryDark=�6:   .��5      �  � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      .+�5      �� $��10,15,15,15q�5      $��22(�5       $
��Bold"�5!      
�������   ApplicationName#���   5#      5$      �� 5&      -   5         ��Name$ listMenuBox��5'      $��1��5(      ��5)      �� *NavigationService.Items+��5*      �� 5+      .R�5,      ��  �� Orientation$ 
Horizontal=�6)   5-      ��50      �� 51      	 �� 
TargetType"	 ��6    .�52      �� 
 �� Property
 �@�FocusVisualStyle �� Value 6A   Z� �� 53      
 � �� 54   "   �� 55   &    �� 
TargetType" ��66   .R�56   *   � .+�57   .   ��  ��Name$ border��65   �� 58   .   $ borderHeader��65   #��z��6K   �� 59   .   #��z��6?   #��z��6�   5:   +    �� Triggers 5<   *   P� 5=   .    P� Property �@��
IsSelected P� Value$
 True��6L   . �5>   2   ��  �� 
TargetName$ borderHeader��69   
 � �� �#ffffff6i   �� 5?   2   $ borderHeader��69   
 �@J�Opacity$	 0.1Q�6f   �� 5@   2   $ border��69   
 � �� �#ffffff6d   �� 5A   2   $ border��69   
 � ��$ 0,0,0,3q�6h   5B   /   P� 5D   .    �@J�IsMouseOver$
 True��6M   . �5E   2   �� $ borderHeader��69   
 � �� �#ffffff6i   �� 5F   2   $ borderHeader��69   
 �@J�Opacity$	 0.1Q�6f   �� 5G   2   $ border��69   
 � �� �#ffffff6d   �� 5H   2   $ border��69   
 � ��$ 0,0,0,3q�6h   5I   /   5K   '   5M      5N      ��5Q      �� 5R      .R�5S      �� $
��20,5q�5T   !   $��16(�5U   !   
���������5W   !   �� *Name+5X      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5[      +  %Microsoft.Xaml.Behaviors.EventTrigger  5\         	EventName$ SelectionChanged��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5]      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *NavigateCommand+   CommandParameter 6X   ��  �� ElementName$ listMenuBox�� �� Path$ SelectedItem�5^      5`      5a      5b      )  #MaterialDesignThemes.Wpf.DialogHost  5d   
   $��1��6   .��5e      )	  #MaterialDesignThemes.Wpf.DrawerHost	  ��6   �� $ MainViewContentControl��$ Content� �� Mode$ TwoWay=� 	  IsTopDrawerOpen 6o   �� *IsTopDrawerOpen+ 	  TopDrawerContent 5f      �� 5g      ��6$   �� *" NavigationService.Items[0].Items+��5h      �� 5i      .R�5j   "   � 5k      ��5n      �� 5o      .R�5p   "   �  5q   &   �� 5r   *   $
��auto �68   �� 5s   *   .+�5v   &   �� $��15,10q�5w   )   $
��Bold"�5x   )   ��5y   )   �� *Name+�� 5{   &   $��1��5|   )   $��15,10q�5}   )   ��5~   )   �� *Items+��5   *   �� 5�   .   .R�5�   2   A�  A� Columns$ 2��6>   5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� $��5q�5�   5   ��5�   5   �� *DataContext.NavigateCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window��5�   5   �� ��5�   5   �� *Name+5�   /   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   -   5          ��Name$  MainViewContentControl��5�      !
 	 Prism.Regions.RegionManager! 
  
RegionName$! MainViewRegion��5�      $y�	Collapsed=�5�      5�      5�      