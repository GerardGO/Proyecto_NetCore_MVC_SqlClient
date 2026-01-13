using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using ProyAspNetCoreMVC_CRUD.Models;
using ProyAspNetCoreMVC_CRUD.Interfaces;
using ProyAspNetCoreMVC_CRUD.Dto;

namespace ProyAspNetCoreMVC_CRUD.Dao
{
    public class ClienteDao:IClienteDao
    {
        //crear variable d solo lectura
        private readonly DBHelper dbHelper;

        //digitar "ctor" para crear constructor rápidamente
        public ClienteDao(DBHelper db)
        {
            dbHelper = db;
        }


        public ClienteResponseDto BuscarCliente(string id)
        {
            ClienteResponseDto? obj = null; // Inicializamos en null

            // Ejecutamos un SP específico que filtre por ID en SQL
            SqlDataReader dr = dbHelper.EjecutarSPDataReader("SP_BUSCAR_CLIENTE_X_COD", id);

            if (dr.Read()) // Si hay una fila, la leemos
            {
                obj = new ClienteResponseDto()
                {
                    cod_cli = dr.GetString(0),//not null
                    nom_cli = dr.GetString(1),//not null
                    tel_cli = dr.IsDBNull(2) ? null : dr.GetString(2), 
                    cor_cli = dr.IsDBNull(3) ? null : dr.GetString(3),
                    dir_cli = dr.IsDBNull(4) ? null : dr.GetString(4),
                    cred_cli = dr.IsDBNull(5) ? null : dr.GetInt32(5),
                    fec_nac = dr.IsDBNull(6) ? null : dr.GetDateTime(6),
                    cod_dist = dr.IsDBNull(7) ? null : dr.GetInt32(7),
                    eli_cli = dr.IsDBNull(8) ? null : dr.GetString(8)
                };
            }
            dr.Close();

            // Si obj sigue siendo null, retornamos uno vacío (si esa es tu lógica) o null
            return obj ?? new ClienteResponseDto();

            
        } //FIN BUSCAR CLIENTE

        public List<ClienteResponseDto> ListarClientesConFiltros(string? cod_cli, string? cor_cli, int? cod_dist)
        {
            var lista = new List<ClienteResponseDto>();

            SqlDataReader dr = dbHelper.EjecutarSPDataReader("SP_LISTAR_CLIENTES_CON_FILTROS", cod_cli, cor_cli, cod_dist);

            while (dr.Read())
            {
                lista.Add(new ClienteResponseDto()
                {
                    cod_cli = dr.GetString(0),
                    nom_cli = dr.GetString(1),
                    tel_cli = dr.IsDBNull(2) ? null : dr.GetString(2), //SE AGREGA SI ES NULL
                    cor_cli = dr.IsDBNull(3) ? null : dr.GetString(3),
                    dir_cli = dr.IsDBNull(4) ? null : dr.GetString(4),
                    cred_cli = dr.IsDBNull(5) ? null : dr.GetInt32(5),
                    fec_nac = dr.IsDBNull(6) ? null : dr.GetDateTime(6),
                    nom_dist = dr.IsDBNull(7) ? null : dr.GetString(7),
                    eli_cli = dr.IsDBNull(8) ? null : dr.GetString(8)
                }
                );
            }

            return lista;
        } //FIN LISTAR CLIENTES CON FILTROS

        public List<ClienteResponseDto> ListarClientes()
        {
            var lista = new List<ClienteResponseDto>();

            SqlDataReader dr = dbHelper.EjecutarSPDataReader("SP_LISTAR_CLIENTES");

            while (dr.Read())
            {
                lista.Add(new ClienteResponseDto()
                {
                    cod_cli = dr.GetString(0),
                    nom_cli = dr.GetString(1),
                    tel_cli = dr.IsDBNull(2) ? null : dr.GetString(2), //SE AGREGA SI ES NULL
                    cor_cli = dr.IsDBNull(3) ? null : dr.GetString(3),
                    dir_cli = dr.IsDBNull(4) ? null : dr.GetString(4),
                    cred_cli = dr.IsDBNull(5) ? null : dr.GetInt32(5),
                    fec_nac = dr.IsDBNull(6) ? null : dr.GetDateTime(6),
                    cod_dist = dr.IsDBNull(7) ? null : dr.GetInt32(7),
                    eli_cli = dr.IsDBNull(8) ? null : dr.GetString(8)
                });
            }
            dr.Close();

            return lista;
        } // FIN LISTAR CLIENTE

        public string GrabarCliente(ClienteRequestDto obj)
        {
            try
            {
                dbHelper.EjecutarSP("SP_CREATE_CLIENTE", obj.nom_cli, obj.tel_cli, obj.cor_cli, obj.dir_cli, obj.cred_cli, obj.fec_nac, obj.cod_dist);
                return "Cliente grabado correctamente.";
            }
            catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
            
        } //FIN GRABAR CLIENTE


        public string ActualizarCliente(ClienteRequestDto obj)
        {
            try
            {
                dbHelper.EjecutarSP("SP_UPDATE_CLIENTE", obj.cod_cli, obj.nom_cli, obj.tel_cli, obj.cor_cli, obj.dir_cli, obj.cred_cli, obj.fec_nac, obj.cod_dist);
                return $"Cliente {obj.cod_cli} actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

        } //FIN ACTUALIZAR CLIENTE


        public string DeshabilitarCliente(string codigo)
        {
            try
            {
                dbHelper.EjecutarSP("SP_DESHABILITAR_CLIENTE", codigo);
                return $"Cliente {codigo} fue deshabilitado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        } //FIN DESHABIILITAR CLIENTE
    }
}
 