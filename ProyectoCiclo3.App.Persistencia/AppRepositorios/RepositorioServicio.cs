using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        private readonly AppContext _appContext = new AppContext();
 
        public IEnumerable<Servicios> GetAll()
        {
            return _appContext.Servicios;
        }
 
        public Servicios GetServicioWithId(int id){
            return _appContext.Servicios.Find(id);
        }

        public Servicios Create(Servicios newServicio)
        {
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;
        }

        public Servicios Update(Servicios newServicio){
            var servicio = _appContext.Servicios.Find(newServicio.id);

            if(servicio != null){
                servicio.origen = newServicio.origen;
                servicio.destino = newServicio.destino;
                servicio.fecha = newServicio.fecha;
                servicio.hora = newServicio.hora;
                servicio.encomienda = newServicio.encomienda;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return servicio;
        }
        public void Delete(int id)
        {
        var user= _appContext.Servicios.Find(id);
       if (user == null)
            return;
        _appContext.Servicios.Remove(user);
        _appContext.SaveChanges();
        }

    }
}
