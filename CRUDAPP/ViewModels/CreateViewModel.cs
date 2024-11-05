using System.ComponentModel;
using System.Runtime.CompilerServices;
using CRUDAPP.Models;
using CRUDAPP.Helpers;
using CRUDAPP.Common;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;

namespace CRUDAPP.ViewModels
{
    public partial class CreateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop_name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop_name));

        public delegate void NotifyEventHandler(object sender, string e);

        public event NotifyEventHandler? Notify;

        public ICommand CreateButtonCommand { get; }


        public string Name
        {
            get => userInfoModel.Name;
            set
            {
                userInfoModel.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get => userInfoModel.Age;
            set
            {
                userInfoModel.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private string DataFilePath;

        public UserInfoModel userInfoModel { get; }

        public CreateViewModel()
        {
            string exeFilePath = Directory.GetCurrentDirectory();
            string? base_path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(exeFilePath)));
            string serializationFolderPath = Path.Combine(base_path, "Data");

            if (!Directory.Exists(serializationFolderPath))
            {
                Directory.CreateDirectory(serializationFolderPath);
            }

            DataFilePath = Path.Combine(base_path, "Data", "Data.json");

            CreateButtonCommand = new CommandHandler(CreateButtonClick, () => true);
            userInfoModel = new UserInfoModel();
        }

        public void CreateButtonClick()
        {
            var newData = new { Name, Age };
            List<object> dataList;

            if (File.Exists(DataFilePath))
            {
                var jsonData = File.ReadAllText(DataFilePath);

                if (jsonData.TrimStart().StartsWith("["))
                {
                    dataList = JsonConvert.DeserializeObject<List<object>>(jsonData) ?? new List<object>();
                }
                else
                {
                    var existingData = JsonConvert.DeserializeObject<object>(jsonData);
                    dataList = new List<object> { existingData };
                }
            }
            else
            {
                dataList = new List<object>();
            }

            dataList.Add(newData);

            var updatedJson = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText(DataFilePath, updatedJson);

            if(Notify is not null)
            {
                SendMessage(ButtonEventName.Create);
            }
        }

        private void SendMessage(string e)
        {
            if(Notify is not null)
            {
                Notify.Invoke(this, e);
            }
        }
    }
}
