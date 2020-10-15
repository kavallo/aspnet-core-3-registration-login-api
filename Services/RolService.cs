using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Migrations.SqlServerMigrations;

namespace WebApi.Services
{
    public interface IRolService
    {
        IEnumerable<Rol> GetAll();
        Rol GetById(int rolId);
        Rol Create(Rol rol);
        void Update(Rol rol);
        void Delete(int rolId);
    }

    public class RolService : IRolService
    {
        private DataContext _context;

        public RolService(DataContext context)
        {
            _context = context;
        }

        public Rol Create(Rol rol)
        {
            try
            {
                var _entidad_descripcion_existe = _context.Roles.Where(x => x.Descripcion.ToString().Trim() == rol.Descripcion.ToString().Trim()).FirstOrDefault();
                if (_entidad_descripcion_existe != null)
                {
                    throw new AppException("La descripción del rol ya existe!");
                }
                else
                {
                    Rol _nuevaEntidad = new Rol();
                    _nuevaEntidad.Descripcion = rol.Descripcion.ToString().Trim();

                    _context.Add(_nuevaEntidad);
                    _context.SaveChanges();

                    return rol;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int rolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Roles;
        }

        public Rol GetById(int rolId)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
