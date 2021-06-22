using Xamarin.Forms;

namespace StorageFacility
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Allows for Navigation to happen bewtween different pages.
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
