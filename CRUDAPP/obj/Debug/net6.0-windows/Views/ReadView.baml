   M S B A M L   `   `   `  ����B  >CRUDAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRUDAPP.ViewsCRUDAPP.Views  5          CRUDAPP.Views.ReadView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CRUDAPP.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��0.1* �6   �� 5      $
��0.9* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��Update��6   ��6&   �� *UpdateButtonCommand+{�6N   �� *CanUpdateOrDelete+�� 5      $��Delete��6   ��6&   �� *DeleteButtonCommand+{�6N   �� *CanUpdateOrDelete+5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns$
 True��6g   ��6    �� *
UserList+ �� SelectedItem 6A   �� *SelectedUser+6g   5      5      