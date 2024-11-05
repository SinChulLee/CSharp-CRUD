using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using CRUDAPP.Models;
using CRUDAPP.Common;
using CRUDAPP.Helpers;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CRUDAPP.ViewModels
{
    public class ReadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop_name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop_name));

        private ObservableCollection<UserInfoModel> userList;

        public ObservableCollection<UserInfoModel> UserList
        {
            get => userList;
            set
            {
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }


        private UserInfoModel selectedUser;
        public UserInfoModel SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
                OnPropertyChanged(nameof(CanUpdateOrDelete));
            }
        }


        public bool CanUpdateOrDelete
        {
            get => SelectedUser != null;
        }


        public ICommand UpdateButtonCommand { get; }
        public ICommand DeleteButtonCommand { get; }

        private string DataFilePath;

        public ReadViewModel()
        {
            string exeFilePath = Directory.GetCurrentDirectory();
            string base_path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(exeFilePath)))!;
            DataFilePath = Path.Combine(base_path, "Data", "Data.json");

            UpdateButtonCommand = new CommandHandler(UpdateButtonClick, () => CanUpdateOrDelete);
            DeleteButtonCommand = new CommandHandler(DeleteButtonClick, () => CanUpdateOrDelete);

            LoadData();
        }

        public void ButtonEvnetFuntion(object sender, string e)
        {
            if(e is not null)
            {
                System.Diagnostics.Debug.WriteLine($"CreateViewModel에서 메시지 수신: {e}");

                if (e == ButtonEventName.Create)
                {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                var jsonData = File.ReadAllText(DataFilePath);
                UserList = JsonConvert.DeserializeObject<ObservableCollection<UserInfoModel>>(jsonData)
                           ?? new ObservableCollection<UserInfoModel>();
            }
            else
            {
                UserList = new ObservableCollection<UserInfoModel>();
            }
        }

        public void UpdateButtonClick()
        {
            var jsonData = JsonConvert.SerializeObject(UserList, Formatting.Indented);
            File.WriteAllText(DataFilePath, jsonData);
            LoadData();
        }

        public void DeleteButtonClick()
        {
            if (SelectedUser != null)
            {
                UserList.Remove(SelectedUser);
                var jsonData = JsonConvert.SerializeObject(UserList, Formatting.Indented);
                File.WriteAllText(DataFilePath, jsonData);
                LoadData();
            }
        }
      
    }
}
