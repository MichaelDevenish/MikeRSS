   M S B A M L   `   `   `  ����E  AMikeRSS V2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MikeRSS_V2
MikeRSS_V2  5
   	       MikeRSS_V2.AddWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   *localclr-namespace:MikeRSS_V2     5
   	      MaterialDesignBody#���   5   
     MaterialDesignPaper#���  5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  	AddWindow��5   	   $	��450��6   $	��750��6(    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Import URL:��6   $
��Left=�65   $	��Top=�6P   $��	10,10,0,0q�6h   �� 5   
   -   5         ��Name$ 
importText��5      $��23��6&   $��
83,11,90,0q�62    �� TextWrapping$
 Wrap=�6F   $��Enter URL Here��6Z   $	��Top=�6p   6�   �� 5   
   -   5         ��Name$ importButton��5      $��Import��6'   $��Right=�68   $��657,10,10,0q�6T   $	��Top=�6i   $��75��6�   $��24��6�   6�   �� 5   
   -   5         ��Name$ listView��5      $	��341��6%   $��	10,39,0,0q�62   $	��Top=�6E   $	��722��6]   	 �� View	 5      �� 5      .P�5      �� $��Website��6%   
 �� Width$	
 300��66    �� DisplayMemberBinding 6B   �� *	Website+�� 5       $	��URL��6%   $	
 450��62    6>   �� *URL+5!       � ContextMenu 5#      �� 5$      .@�5%      m� -   5        $��Delete��5%      6/   5&      5(      �� 5)   
   -   5        $ importButton_Copy��5)      $��Accept��6,   $��Right=�6=   $��
0,385,90,0q�6Y   $	��Top=�6m   $��24��6�   6�   �� 5*   
   -   5        $ importButton_Copy1��5*      $��Export List��6-   $
��Left=�6C   $��166,385,0,0q�6^   $	��Top=�6s   $��24��6�   6�   �� 5+   
   -   5        $ importButton_Copy2��5+      $
��Load��6-   $
��Left=�6<   $��
98,385,0,0q�6W   $	��Top=�6k   $��24��6�   6�   �� 5,   
   -	   5        $ importButton_Copy3��5,      $��Remove��6-   $
��Left=�6>   $��
10,385,0,0q�6Y   $	��Top=�6m   $��24��6�   6�   �� 5-   
   -
   5        $ importButton_Copy4��5-      $��Cancel��6-   $��Right=�6>   $��
0,385,10,0q�6Z   $	��Top=�6n   $��24��6�   6�   5.      5/      