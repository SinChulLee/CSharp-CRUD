namespace CRUDAPP.Models
{
    public class UserInfoModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public UserInfoModel()
        {
            Name = string.Empty;
            Age = 0;
        }
    }
}
