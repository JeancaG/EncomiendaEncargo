using Dapper;
using Datos.Interfaces;
using Modelo;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;

        public UsuarioRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "UPDATE Usuario SET Codigo = @Codigo, Nombre = @Nombre, Clave = @Clave, Rol = @Rol, EstaActivo = @EstaActivo WHERE Codigo = @Codigo ;";
                 resultado = await conexion.ExecuteAsync(sql, new {usuario.Codigo, usuario.Nombre, usuario.Clave, 
                                                                usuario.Rol, usuario.EstaActivo});
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Eliminar(Usuario usuario)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "DELETE FROM Usuario WHERE Codigo = @Codigo;";
                resultado = await conexion.ExecuteAsync(sql, new { usuario.Codigo });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            IEnumerable<Usuario> lista = new List<Usuario>();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM Usuario;";
                lista = await conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Usuario> GetPorCodigo(string codigoUsuario)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM Usuario WHERE Codigo = @Codigo;";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigoUsuario });
            }
            catch (Exception)
            {
            }
            return user;
        }
        public async Task<bool> Nuevo(Usuario usuario)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "INSERT INTO Usuario (Codigo, Nombre, Clave, Rol, EstaActivo) VALUES (@Codigo, @Nombre, @Rol, @Clave, @EstaActivo)";
                resultado = await conexion.ExecuteAsync(sql, usuario);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
