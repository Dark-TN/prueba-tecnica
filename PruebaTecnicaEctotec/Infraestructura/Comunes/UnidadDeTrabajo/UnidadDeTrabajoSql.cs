using Dominio.Comunes.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Comunes.UnidadDeTrabajo
{
    public class UnidadDeTrabajoSql : IUnidadDeTrabajo
    {
        public Guid Id { get; private set; }
        public IDbConnection Conexion { get; }
        public IDbTransaction Transaccion { get; private set; }
        public UnidadDeTrabajoSql(string cadenaConexion)
        {
            this.Id = Guid.NewGuid();
            this.Conexion = new SqlConnection(cadenaConexion);
            this.Conexion.Open();
            this.Transaccion = null;
        }
        public void Comenzar()
        {
            Transaccion = Conexion.BeginTransaction();
        }
        public void Completar()
        {
            Transaccion.Commit();
        }
        public void Retroceder()
        {
            Transaccion.Rollback();
        }
        public void Dispose()
        {
            this.Conexion.Dispose();
            if (Transaccion != null)
                Transaccion.Dispose();
            Transaccion = null;
        }
    }
}
