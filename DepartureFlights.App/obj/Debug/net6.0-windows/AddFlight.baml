   M S B A M L   `   `   `  ����O  KDepartureFlights.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DepartureFlights.AppDepartureFlights.App  5      $    DepartureFlights.App.AddFlight   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:DepartureFlights.App     5        N� 
Background
  ����� N� Title$ 	AddFlight��5	      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��250 �6   �� 5      $
��Auto �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   .+�5    
   �� $��0��6   $��0��6   .��6.   Fecha65   &   System.Windows.Controls.Calendar  5!   
   -   5        $
��Date��5!      $��3��6    $��1��62   $��0,0,0,10q�6B   �� 5#   
   $��3��6   $��0��6   .��6-   Hora de Salida6=   �� 5$   
   -   5        $��DepartureTime��5$      $��40��6   $��3��63   $��1��6@   $��Center=�6P   $��Center=�6r   $��0,0,0,10q�6�   �� 5&   
   $��4��6   $��0��6   .��6-   Hora de Llegada6>   �� 5'   
   -   5        $��ArrivalTime��5'      $��40��6   $��4��61   $��1��6>   $��Center=�6N   $��Center=�6p   $��0,0,0,10q�6�   �� 5)   
   $��2��6   $��2��6   .��6-   	Aerolinea68   �� 5*   
   -   5        $��Airline��5*      $��40��6!   $��2��6-   $��3��6:   $��Center=�6J   $��Center=�6l   $��0,0,0,10q�6�   ��5+      �� 5,      .R�5-      �� ��6    �� *Name+5.      50      �� 52   
   $��1��6   $��2��6   .��6-   	Destino66   �� 53   
   -   5        $��Destination��53      $��40��6%   $��1��61   $��3��6>   $��Center=�6N   $��Center=�6p   $��0,0,0,10q�6�   ��54      �� 55      .R�56      �� ��6    �� *Name+57      59      �� 5;   
   $��0��6   $��2��6   .��6-   Origen65   �� 5<   
   -   5        $��Origin��5<      $��40��6    $��0��6,   $��3��69   $��Center=�6I   $��Center=�6k   $��0,0,0,10q�6�   ��5=      �� 5>      .R�5?      �� ��6    �� *Name+5@      5B      �� 5D   
   $��3��6   $��2��6   .��6.   Status66   �� 5E   
   -   5        $��Status��5E      $��40��6    $��3��6,   $��3��69   $��Center=�6I   $��Center=�6k   $��0,0,0,10q�6�   ��5F      �� 5G      .R�5H      �� ��6    �� *Name+5I      5K      �� 5M   
   -   5        $��3��5M   &   $	��150��66   $��4��6C   $��Right=�6P   $��10q�6l   
����+��.��6�   Agregar Datos De Vuelo6�   �� 5N   
   -	   5        $��0��5N      $	��190��6!   $��6��6F   $
��Left=�6S   $��10q�6n   .��6z   Agregar Nuevo Status De Vuelo6�   �� 5O   
   -
   5        $��1��5O      $	��190��6!   $��6��6G   $��Right=�6T   $��10q�6p   .��6|   Agregar Nueva Aerolínea6�   �� 5P   
   -   5        $��4��5P      $	��190��6!   $��6��6D   $
��Left=�6Q   $
��0,10q�6l   .��6z   Agregar Nueva Ciudad6�   �� 5R   
   -   5        $��	newStatus��5R      $	��190��6#   $��40��6/   $��7��6;   $��0��6H   $��0,0,0,10q�6X   $��Center=�6j   $��Center=�6�   �� 5S   
   -   5        $��
newAirline��5S      $	��190��6$   $��40��60   $��7��6<   $��Right=�6I   $��1��6e   $��10q�6u   $��Center=�6�   $��Center=�6�   �� 5T   
   -   5        $��newCity��5T      $	��190��6!   $��40��6-   $��7��69   $��4��6F   $
��Left=�6V   $
��0,10q�6q   $��Center=�6   $��Center=�6�   5V      5W      