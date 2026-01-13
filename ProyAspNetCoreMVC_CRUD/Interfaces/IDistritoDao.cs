using Microsoft.Data.SqlClient;
using ProyAspNetCoreMVC_CRUD.Models;

namespace ProyAspNetCoreMVC_CRUD.Interfaces
{
    public interface IDistritoDao
    {
        public List<Distrito> ListarDistritos();
    }
}
