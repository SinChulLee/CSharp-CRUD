namespace CRUDAPP.ViewModels
{
    public class MainViewModel
    {
        public CreateViewModel CreateViewModel { get; set; }
        public ReadViewModel ReadViewModel { get; set; }

        public MainViewModel() 
        {
            CreateViewModel = new CreateViewModel();
            ReadViewModel = new ReadViewModel();

            CreateViewModel.Notify += ReadViewModel.ButtonEvnetFuntion;
        }
    }
}
