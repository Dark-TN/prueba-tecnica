using Dapper;
using Dominio.Comunes.UnidadDeTrabajo;
using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class RepositorioCatalogoCiudadEstadoSql : IRepositorioCatalogoCiudadEstado
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public RepositorioCatalogoCiudadEstadoSql(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public IEnumerable<CatalogoCiudadEstado> ObtenerPorNombre(string nombre)
        {
            string sqlStr = @"Exec Catalogos_CatalogoCiudadEstadoObtenerPorNombre @nombre";
            try
            {
                return _unidadDeTrabajo.Conexion.Query<CatalogoCiudadEstado>(sqlStr, new { nombre });
            }
            catch(SqlException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
