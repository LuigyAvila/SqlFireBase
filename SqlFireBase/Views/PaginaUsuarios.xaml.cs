using System;
using System.Threading.Tasks;
using SqlFireBase.Models;
using SqlFireBase.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlFireBase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaUsuarios : ContentPage
    {
        public PaginaUsuarios()
        {
            InitializeComponent();
            mostrar_usuarios();
        }

        private async void btnsave_Clicked(object sender, EventArgs e)
        {
            await InsertarUsuarios();
        }

        private async Task InsertarUsuarios()
        {
            UsuariosViewModel funcion = new UsuariosViewModel();
            UsuariosModel parametros = new UsuariosModel();
            parametros.Usuario=txtusuario.Text;
            parametros.Pass=txtcontraseña.Text;
            parametros.Icono = "-";
            parametros.Estado = "-";
            await funcion.insertar_usuarios(parametros);
            await DisplayAlert("listo", "Usuarios agregados", "Ok");
            await mostrar_usuarios();

        }

        public async Task mostrar_usuarios()
        {
            UsuariosViewModel funcion = new UsuariosViewModel();
            var datos = await funcion.mostrar_usuarios();
            listaUsuarios.ItemsSource = datos;

        }
    }
}