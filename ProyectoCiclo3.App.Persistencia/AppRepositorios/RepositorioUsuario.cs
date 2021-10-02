using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> Usuario;
 
    public RepositorioUsuario()
        {
            Usuario= new List<Usuario>()
            {
                new Usuario{id=1,nombre="Juan Pablo",apellidos= "Rodríguez",direccion= "calle 16 cra 14 norte",telefono= "3015684985",ciudad= "Armenia"},
                new Usuario{id=2,nombre="Camila",apellidos= "Marín",direccion= "condominio casas blancas",telefono= "3002541685",ciudad= "Medellin"},
                new Usuario{id=3,nombre="Miguel",apellidos= "Henao",direccion= "calle 23 #26-59",telefono= "3134563791",ciudad= "Cali"}
 
            };
        }
 
        public IEnumerable<Usuario> GetAll()
        {
            return Usuario;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return Usuario.SingleOrDefault(b => b.id == id);
        }

        public Usuario Update(Usuario newUsuario){
            var usuario= Usuario.SingleOrDefault(b => b.id == newUsuario.id);
            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellidos = newUsuario.apellidos;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
                usuario.ciudad = newUsuario.ciudad;
            }
        return usuario;
        }

    }
}
