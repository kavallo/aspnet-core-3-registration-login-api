using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
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
        public Rol Create(Rol rol)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetAll()
        {
            throw new NotImplementedException();
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
