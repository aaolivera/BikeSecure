using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorio
{
    public class RepositorioEf : IRepositorio
    {
        private const int SqlFkError = 547;
        
        private readonly DbContext context;

        public RepositorioEf(DbContext context)
        {
            this.context = context;
        }

        private IDbSet<TEntidad> Set<TEntidad>() where TEntidad : class
        {
            return context.Set<TEntidad>();
        }

        public TEntidad Obtener<TEntidad>(object id) where TEntidad : class
        {
            return Set<TEntidad>().Find(id);
        }

        public TEntidad ObtenerUnchanged<TEntidad>(object id) where TEntidad : class
        {
            var entity = Set<TEntidad>().Find(id);
            context.Entry(entity).State = EntityState.Unchanged;
            return entity;
        }
        
        public TEntidad Obtener<TEntidad>(Expression<Func<TEntidad, bool>> filtro) where TEntidad : class
        {
            return Set<TEntidad>().SingleOrDefault(filtro);
        }

        public IList<TEntidad> Listar<TEntidad>(Expression<Func<TEntidad, bool>> filtro = null) where TEntidad : class
        {
            IQueryable<TEntidad> resultado = Set<TEntidad>();
            if (filtro != null)
            {
                resultado = resultado.Where(filtro);
            }
            return resultado.ToList();
        }

        public int Contar<TEntidad>() where TEntidad : class
        {
            return Set<TEntidad>().Count();
        }

        public int Contar<TEntidad>(Expression<Func<TEntidad, bool>> filtro) where TEntidad : class
        {
            return Set<TEntidad>().Count(filtro);
        }

        public bool Existe<TEntidad>(Expression<Func<TEntidad, bool>> filtro) where TEntidad : class
        {
            return Set<TEntidad>().Any(filtro);
        }

        public TEntidad Agregar<TEntidad>(TEntidad entidad) where TEntidad : class
        {
            return Set<TEntidad>().Add(entidad);
        }

        public TEntidad Remover<TEntidad>(object id) where TEntidad : class
        {
            return Remover(Obtener<TEntidad>(id));
        }

        public TEntidad Remover<TEntidad>(TEntidad entidad) where TEntidad : class
        {
            return Set<TEntidad>().Remove(entidad);
        }

        public int GuardarCambios()
        {
            try {
                return context.SaveChanges();
            }
            catch (DataException e)
            {
                if (ObtenerCodigoError(e) == SqlFkError)
                {
                    throw new EntidadReferenciadaException(string.Empty, e);
                }
                throw;
            }
        }

        private int ObtenerCodigoError(DataException e)
        {
            var code = 0;
            if(e.InnerException != null)
            {
                var sqlEx = e.InnerException.InnerException as SqlException;
                if (sqlEx != null)
                {
                    code = sqlEx.Number;
                }
            }
            return code;
        }

    }
}
