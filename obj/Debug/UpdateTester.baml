   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.UpdateTester   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  UpdateTester��5   	   $	��500��6   $	��500��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ 
Main_label��5
      $��16(�6$   $��Create an account��62   $
��Left=�6N   $	��Top=�6i   $	��164��6�   $��	176,0,0,0q�6�   �� 5   
   $��Identify Address:��6   $��0��6,   $
��Left=�6<   $��12,38,0,405q�6W   $��0��6l   $��Center=�6y   �� 5   
   -   5         ��Name$ MaximumTextBox��5      $
��Left=�6*   $��23��6E   $��331,256,0,190q�6Q   $��0��6h   $��Center=�6�   $	��120��6�   ��6u   �� *branchAddress+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5   
   $��Tester First Name:��6   $��0��6-   $��12,69,-6,374q�6=   $��Center=�6S   �� 5   
   $��Tester last Name:��6   $��0��6,   $��12,101,-6,342q�6<   $��Center=�6S   �� 5   
   -   5        $ TextBox��5      $��24��6#   $��331,225,41,220q�6/   $��Center=�6�   $	��120��6�   ��6G   �� *
branchName+$ TwoWay=� .  . 6�   �� 5   
   $��	birthday:��6   $��0��6$   $��12,163,318,280q�64   $��Center=�6L   �� 5   
   -   5        $ TelephoneTextBox��5      $
��Left=�6,   $��23��6G   $��331,191,0,255q�6S   $��Center=�6�   $	��120��6�   ��6j   �� *branchNumber+$ TwoWay=� .  . 6�   �� 5   
   $��Years of experience:��6   $��0��6/   $
��Left=�6?   $��10,225,0,218q�6Z   $��Center=�6p   �� 5   
   -   5        $ BirthdayTextBox��5      $
��Left=�6+   $��23��6F   $��331,163,0,283q�6R   $��Center=�6�   $	��120��6�   ��6i   �� *branchNumWorkers+$ TwoWay=� .  . 6�   �� 5   
   $��Gender:��6   $��0��6"   $
��Left=�62   $��12,132,0,311q�6M   $��Center=�6c   �� 5   
   -   5        $ TesterLastNameTextBox��5      $
��Left=�61   $��23��6L   $��331,100,0,346q�6X   $��Center=�6�   $	��120��6�   ��6o   �� *branchPhone+$ TwoWay=� .  . 6�   �� 5   
   $*��$The maximum number of Test per week:��6   $��0��6?   $
��Left=�6O   $��12,253,0,190q�6j   $��Center=�6�   �� 5   
   $��The type of vechile:��6   $��0��6/   $
��Left=�6?   $��14,292,0,151q�6Z   $��Center=�6p   �� 5   
   -   5        $ FirstNameTextBox��5      $
��Left=�6,   $��23��6G   $��331,69,0,377q�6S   $��Center=�6�   $	��120��6�   ��6i   �� *freeDeliverNum+$ TwoWay=� .  . 6�   �� 5   
   $��Telephone Number:��6   $��0��6,   $
��Left=�6<   $��12,196,0,247q�6W   $��Center=�6m   �� 5   
   -   5         ��Name$ 	comboBox1��5      $
��Auto��6H   $��331,132,41,315q�6V   $��Center=�6n   $	��120��6�    �� SelectedItem 6&   �� *
hechsher+6�   �� 5   
   -	   5        $ label1��5      $��Maximum distance��6    $
��Left=�6;   $��32��6V   $��
12,347,0,0q�6b   $	��Top=�6v   $	��239��6�   �� 5   
   -
   5        $ 	comboBox2��5      $
��Left=�6&   $��26��6A   $��331,292,0,0q�6M   $	��Top=�6b   $	��120��6z   �� 5   
   -   5        $ textBox1��5      $
��Left=�6$   $��28��6?   $��331,351,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        	 ��Name$	 button��5      $��UPDATE��6!   $
��Left=�62   $��42��6M   $��340,417,0,0q�6Y   $	��Top=�6n   $	��111��6�   6�   �� 5   
   �� 5    
   -   5        $ 	comboBox6��5       $
��Left=�6&   $��
130,36,0,0q�6A   $	��Top=�6U   $	��321��6m   6y   5!      5"      