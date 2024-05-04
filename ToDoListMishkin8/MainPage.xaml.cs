namespace ToDoListMishkin8
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TaskViewModel();
        }
    }

}
