   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity   
WPFProject"   WPFProject.Views.AddListView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     Hi19http://schemas.microsoft.com/winfx/2006/xaml/presentation     $	��800��$
��1080��  N� Title$  AddListView��.��� ���#e8eaf6 � RowDefinitions �� $��55 ��� $��35 ��� $��* �.+�&   System.Windows.Controls.DataGrid  .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *
LoadAction+� $��0�����#e8eaf6 � ColumnDefinitions �� $	��270 ��� $	��270 ��� $	��270 ��� $	��270 �.+��� $��1��$��2��$��55��$��Dodaj Nowy Film��$��24(�$
��Bold"�$��Center=�$��Center=�� $��1�� �� $	��270 ��� $	��270 ��� $	��270 ��� $	��270 �.+��� $��1��$��2��$��Center=�$��Center=�
���  ��$��18(�$
��Bold"����� *ErrorMessage+� $��2�� J� RenderTransformOrigin$ 	0.5,0.656&� �� $��45 ��� $��45 ��� $��45 ��� $��45 ��� $��71 ��� $��45 ��� $��80 � �� $	��270 ��� $	��270 ��� $	��270 ��� $	��270 �.+��� $��0��$��1��$��	0,10,10,0q�$��Nazwa Filmu��$��16(�$
��Bold"�$��Center=�$��Center=��� -   $��	movieName��$��2��$��0,10,0,0q�$��Center=�$��Center=����� *
MovieTitle+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� ValidatesOnDataErrors$
	 True��
 �� NotifyOnValidationError$

 True�� �� ValidatesOnExceptions$
 True��" �� ValidatesOnNotifyDataErrors$
 True��.���� $��1��$��1��$��	0,10,10,0q�$��Gatunek Filmu��$��16(�$
��Bold"�$��Center=�$��Center=���  �� SelectedIndex$ 0��$��1��$��2��$��14(�$
��auto��$��0,10,0,0q� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	GenreName������ *
GenresList+ �� SelectedValue �� *
MovieGenre+�� $��2��$��1��$��	0,10,10,0q�$��Platformy VOD��$��16(�$
��Bold"�$��Center=�$��Center=��� $ 0��$��14(�$��2��$��2��$
��auto��$��0,10,0,0q�$ Id��$ PlatformName������ *PlatformsList+ �� *MoviePlatform+�� $��3��$��1��$��	0,10,10,0q�$��Ocena Filmu��$��16(�$
��Bold"�$��Center=�$��Center=��� $ 3��$��14(�$��3��$��2��$
��auto��$��0,10,0,0q�$ Id��$ 
RatingName�� �� *
UserRating+���� *
RatingList+�� $��4��$��1��$��	0,10,10,0q�$��Krótki Opis��$��16(�$
��Bold"�$��Center=�$��Center=��� -   $��Description��$��4��$��2��$��0,10,0,0q�$
��Left=�$	��Top=�$��10q� �� TextWrapping$
 Wrap=����� *Description+.���� $��5��$��1��$��	0,10,10,0q�$��
Dodaj jako��$��16(�$
��Bold"�$��Center=�$��Center=��� $��14(�$��5��$��2��$
��auto��$��0,10,0,0q�$ UserName��$ 0��$ Id�� �� *User+���� *AvaliableUsers+��  � Cursor$
 Hand��$��Center=�$��Center=�$	��250��$��45��$��6��$��1��$��2��$��0,15,0,3q�$��16(����� *ButtonContent+���� *SubmitAction+{��� *	IsEnabled+