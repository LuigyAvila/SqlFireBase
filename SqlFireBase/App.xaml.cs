using SqlFireBase.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlFireBase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaUsuarios();
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
