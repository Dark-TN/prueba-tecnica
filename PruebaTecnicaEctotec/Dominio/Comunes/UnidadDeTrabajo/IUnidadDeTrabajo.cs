using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Comunes.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        Guid Id { get; }
        IDbConnection Conexion { get; }
        IDbTransaction Transaccion { get; }
        void Comenzar();
        void Completar();
        void Retroceder();
    }
}
