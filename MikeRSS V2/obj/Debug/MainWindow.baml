   M S B A M L   `   `   `  ����E  AMikeRSS V2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MikeRSS_V2
MikeRSS_V2  5   	       MikeRSS_V2.MainWindow   5   	   U QMaterialDesignThemes.Wpf, Version=1.4.1.485, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5	   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
   	   *localclr-namespace:MikeRSS_V2     5   	   -   5           MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1150��6)    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      � $��0,0,0,0q�6    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��204* �6   �� 5      $
��388* �6    � ColumnDefinitions 5    
   �� 5!      $
��240* �6   �� 5"      $
��865* �6   .+�5$   
   �� -   5         ��Name$ gridSplitter��5$      $
��Left=�6-   $��6��6H   $��1��6R    J� RenderTransformOrigin$ 0.5,0.5&�6b   $��0,3,0,0q�6�   $��2��6�   $��1��6�   �� 5&   
   -   5         ��Name$ label��5&      $��Imported Feeds��6   $��10,1,0,0q�68   $	��Top=�6J   $��28��6b   $��1��6n   �� 5'   
   -   5        $ label1��5'      $��Label��6    $
��Left=�60   $��0��6K   $��
-116,1,0,0q�6V   $	��Top=�6j   $��3��6�   $��2��6�   �� 5(   
   -   5        $ 
label_Copy��5(      $��Current Feed's Articles��6$   $��10,3,5,0q�6F   $	��Top=�6X   $��24��6p   $��2��6|   `� 5)   
   $
��Left=�6   $��30��61   $	��Top=�6=   $
��1142��6U   $��2��6b   $��2��6v   .�5*      c� 	 c� Band$	 1��6   
 c� 	BandIndex$
 1��6   .@�5+      �� -   5          MaterialDesignToolButton#���  5+      $��24��5,   !   $��24��6-   $��Bottom=�6L   .��5-      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=1.4.1.485, Culture=neutral, PublicKeyToken=null]]   Kind$ PlusBox=�6.    J� Opacity$	 .56Q�6=   5.      �� 50      -   5        #���  50      $��24��51   !   $��24��6-   $��5,1,0,0q�68   .��52        $	 Web=�6.   $	 .56Q�69   53      �� 54      -   5        #���  54      $��24��55   !   $��24��6-   $��5,1,0,0q�68   .��56        $ 
HelpCircle=�6.   $	 .56Q�6@   57      58      c� 59      $	 1��6   $
 2��6   .@�5:      �� -	   5        #���  5:      $��24��5;   !   $��24��6-   $��5,1,0,0q�68   .��5<        $ 	ArrowLeft=�6.   $	 .56Q�6?   5=      �� 5>      -
   5        #���  5>      $��24��5?   !   $��24��6-   $��5,1,0,0q�68   .��5@        $ 
ArrowRight=�6.   $	 .56Q�6@   5A      5B      5C      � 5D   
   -   5         �Name$ progressBar��5D      $	��Top=�6+   $��1��6C   $��0q�6S   $��4��6^   $��1��6i   (  "System.Windows.Controls.WebBrowser  5E   
   -   5          Name$ 
webBrowser��5E      $��1��6)   $��5,4,0,0q�69   $��2��6J   $��1��6[   6�   �� 5F   
   -   5         ��Name$ 	feedsView��5F      $��0,29,0,7q�6&   $��1��68    �� SelectionMode$ Single=�6s    �� View 5G      �� 5H      .P�5I      ��  �� Width$	 120��6%    �� DisplayMemberBinding 61   �� *Name+��5J      �� 5K      
 � Tag$
 Name��63   .��6A   Name6G   5M      �� 5N      $	 100��6%    61   �� *URL+��5O      �� 5P      $	 URL��63   .��6@   URL6E   5R      5S      5U      �� 5V   
   -   5        $ articlesView��5V      $��0,27,0,0q�6)   $��2��6;   $ Single=�6y    5W      �� 5X      .P�5Y      �� $ 20��6%    60   �� *Number+.��5Z      �� $��#��6/   5[      �� 5\      $	 200��6&    62   �� *Title+.��5]      �� $��Title��6/   5^      �� 5_      $	 200��6%    61   �� *URL+.��5`      �� $	��URL��6/   5a      5b      5d      �� 5e   
   -   5        $ gridSplitter1��5e      $��Stretch=�6.    �� ResizeDirection$
 Rows=�6L   $��Bottom=�6c   $��5��6~   $��1��6�   5g      5h      