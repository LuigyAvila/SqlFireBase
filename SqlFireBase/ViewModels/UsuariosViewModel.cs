using SqlFireBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqlFireBase.Services;
using Firebase.Database.Query;
using Firebase.Storage;
using System.IO;

namespace SqlFireBase.ViewModels
{
    public class UsuariosViewModel
    {
        List<UsuariosModel> usuarios =new List<UsuariosModel>();
        string rutaFoto;

        public async Task  <List<UsuariosModel>> mostrar_usuarios()
        {
            var data = await ConextionFireBase.firebase
                .Child("Usuarios")
                .OrderByKey()
                .OnceAsync<UsuariosModel>();
            foreach (var datos in data)
            {
                UsuariosModel parametros = new UsuariosModel();
                parametros.Id_usuario = datos.Key;
                parametros.Usuario = datos.Object.Usuario;
                parametros.Pass = datos.Object.Pass;
                parametros.Icono = datos.Object.Icono;
                parametros.Estado = datos.Object.Estado;
                usuarios.Add(parametros);
            }
            return usuarios;
        }
        public async Task insertar_usuarios(UsuariosModel parametros)
        {
            var data = await ConextionFireBase.firebase
                .Child("Usuarios")
                .PostAsync(new UsuariosModel()
                {
                    Usuario= parametros.Usuario,
                    Pass=parametros.Pass,
                    Icono=parametros.Icono,
                    Estado=parametros.Estado,
                    
                });
        }

        public async Task<string> SubirImagenesStorage(Stream ImagenStream,string Idusuarios)
        {
            var dataAlmacenamiento = await new FirebaseStorage("usuarios-6f699.appspot.com")
                .Child("Usuarios")
                .Child(Idusuarios + ".jpg")
                .PutAsync(ImagenStream);
            rutaFoto = dataAlmacenamiento;
            return rutaFoto;
        }
       
    }
}
