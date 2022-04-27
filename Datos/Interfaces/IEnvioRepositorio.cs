using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IEnvioRepositorio
    {
        Task<bool> Nuevo(Envio envio);
        Task<bool> Actualizar(Envio envio);
        Task<bool> Eliminar(Envio envio);
        Task<IEnumerable<Envio>> GetLista();
        Task<Envio> GetPorCodigo(string codigoEnvio);
    }
}
