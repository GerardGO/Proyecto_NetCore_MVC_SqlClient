using Microsoft.Data.SqlClient;
using ProyAspNetCoreMVC_CRUD.Dto;
using ProyAspNetCoreMVC_CRUD.Models;

namespace ProyAspNetCoreMVC_CRUD.Interfaces
{
    public interface IClienteDao
    {
        ClienteResponseDto BuscarCliente(string id);

        List<ClienteResponseDto> ListarClientesConFiltros(string? cod_cli, string? cor_cli, int? cod_dist);

        List<ClienteResponseDto> ListarClientes();

        string GrabarCliente(ClienteRequestDto obj);

        public string ActualizarCliente(ClienteRequestDto obj);

        public string DeshabilitarCliente(string codigo);
    }
}
