using Dapper;
using Datos.Interfaces;
using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class EnvioRepositorio : IEnvioRepositorio
    {
        private string CadenaConexion;

        public EnvioRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Envio envio)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "UPDATE envio SET CodigoEnvio = @CodigoEnvio, Remitente = @Remitente, Descripcion = @Descripcion, DireccionEntrega = @DireccionEntrega, FechaEnvio = @FechaEnvio, Tarifa = @Tarifa, Impuesto = @Impuesto, Total = @Total WHERE CodigoEnvio = @CodigoEnvio ;";
                resultado = await conexion.ExecuteAsync(sql, new
                {
                    envio.CodigoEnvio,
                    envio.Remitente,
                    envio.Descripcion,
                    envio.DireccionEntrega,
                    envio.FechaEnvio,
                    envio.Tarifa,
                    envio.Impuesto,
                    envio.Total
                });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Eliminar(Envio envio)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "DELETE FROM envio WHERE CodigoEnvio = @CodigoEnvio;";
                resultado = await conexion.ExecuteAsync(sql, new { envio.CodigoEnvio });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Envio>> GetLista()
        {
            IEnumerable<Envio> lista = new List<Envio>();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM envio;";
                lista = await conexion.QueryAsync<Envio>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Envio> GetPorCodigo(string codigoEnvio)
        {
            Envio ship = new Envio();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM envio WHERE CodigoEnvio = @CodigoEnvio;";
                ship = await conexion.QueryFirstAsync<Envio>(sql, new { codigoEnvio });
            }
            catch (Exception)
            {
            }
            return ship;
        }
        public async Task<bool> Nuevo(Envio envio)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "INSERT INTO envio (CodigoEnvio, Remitente, Descripcion, DireccionEntrega, FechaEnvio, Tarifa, Impuesto, Total) VALUES (@CodigoEnvio, @Remitente, @Descripcion, @DireccionEntrega, @FechaEnvio, @Tarifa, @Impuesto, @Total)";
                resultado = await conexion.ExecuteAsync(sql, envio);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
     
    }
}
