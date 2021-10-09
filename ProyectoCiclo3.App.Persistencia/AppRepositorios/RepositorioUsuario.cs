using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> Usuario;
        private readonly AppContext _appContext = new AppContext();
 
        public IEnumerable<Usuario> GetAll()
        {
            return _appContext.Usuario;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuario.Find(id);
        }

        public Usuario Create(Usuario newUsuario)
        {
            var addUsuario = _appContext.Usuario.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;
        }

        public Usuario Update(Usuario newUsuario){
            var usuario = _appContext.Usuario.Find(newUsuario.id);

            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellidos = newUsuario.apellidos;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
                usuario.ciudad = newUsuario.ciudad;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return usuario;
        }
        public void Delete(int id)
        {
        var User= _appContext.Usuario.Find(id);
       if (User == null)
            return;
        _appContext.Usuario.Remove(User);
        _appContext.SaveChanges();
        }

    }
}
