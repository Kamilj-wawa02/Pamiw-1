   M S B A M L   `   `   `  ����W  SP04WeatherForecastAPI.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:P04WeatherForecastAPI.ClientP04WeatherForecastAPI.Client  5   	   -    'P04WeatherForecastAPI.Client.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:P04WeatherForecastAPI.Client     5   	     � Title$  
MainWindow��5   	   $	��398��6   $	��697��6)   .��5	      ]� .+�5
   
   �� $	��152��6   $
��Left=�6!   .+�5      �� $��City:��6   6'   �� 5      -   5         ��Name$ txtCity��5      6)   �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6(   6S   �� 5      -   5         ��Name$ lbCities��5       �� DisplayMemberPath$ LocalizedName��6(   6w   5      �� 5   
   $	��151��6   .+�5      �� $��Center=�6   $��Temperature for city:��61   6S   �� 5      -   5         ��Name$ lblCityName��5      $��Center=�6)   $	��...��6F   6V   �� 5      $��Center=�6   $	��is:��62   6B   �� 5      -   5        $ lblTemperatureValue��5      $��Center=�61   $��..��6N   6]   �� 5      $��Yesterday was:��6   $	��106��6-   �� 5      -   5        $" lblTemperatureYesterdayValue��5      $��..��6:   $��16��6G   �� 5      $��In 1 hour will be:��6   $	��106��61   �� 5      -   5        $  lblTemperatureIn1HourValue��5      $��..��68   $��16��6E   5      �� 5   
   $
��Left=�6   $	��124��6+   .+�5      �� $��Hourly
temperatures:��6   $��46��6<   �� 5      -   5        $ lbHourlyTemperatures��5      ${�False��64   5      �� 5   
   $
��Left=�6   $	��111��6+   .+�5      �� -	   5        $ 
btnSearch1��5      $��Load regions��6)   6@   �� 5       $��All regions:��6   �� 5!      -
   5        $ 	lbRegions��5!      $ LocalizedName��6)   6K   5"      �� 5#   
   $
��Left=�6   $	��152��6+   $
��Left=�67   .+�5$      �� $��Countries in
region:��6   �� 5%      -   5        $ lbCountries��5%      $ LocalizedName��6+   ${�False��6x   5&      5'      5(      